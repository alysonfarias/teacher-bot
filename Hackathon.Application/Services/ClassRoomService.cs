using AutoMapper;
using FluentValidation;
using Hackathon.Application.CustomExceptions;
using Hackathon.Application.DTOS.Activity;
using Hackathon.Application.DTOS.ClassRoom;
using Hackathon.Application.Interfaces.Services;
using Hackathon.Domain.Interfaces;
using Hackathon.Domain.Interfaces.Repositories;
using Hackathon.Domain.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using SendGrid;
using SendGrid.Helpers.Mail;

namespace Hackathon.Application.Services
{
    public class ClassRoomService : IClassRoomService
    {
        public IClassRoomRepository _classRoomRepository { get; set; }
        public IValidator<ClassRoomRequest> _classRoomValidator { get; set; }
        public IMapper _mapper { get; set; }
        public IUnitOfWork _unitOfWork { get; set; }
        public IAuthService _authService {get;set;}


        public ClassRoomService
        (
            IClassRoomRepository classRoomRepository,
            IValidator<ClassRoomRequest> classRoomValidator,
            IMapper mapper,
            IUnitOfWork unitOfWork,
            IAuthService authService 
        )
        {
            _classRoomRepository = classRoomRepository;
            _classRoomValidator = classRoomValidator;
            _mapper = mapper;
            _unitOfWork = unitOfWork;
            _authService = authService;

            _classRoomRepository.AddPreQuery(x => x
            .Include(x => x.Activities)
            .ThenInclude(x => x.Arquives)
            );

        }

        public async Task<ClassRoomResponse> RegisterAsync(ClassRoomRequest classRoomRequest, int intructorId)
        {
            var validationResult = await _classRoomValidator.ValidateAsync(classRoomRequest);
            if( ! validationResult.IsValid)
                throw new BadRequestException(validationResult);
            
            var classRoom = _mapper.Map<ClassRoom>(classRoomRequest);
            classRoom.InstructorId = intructorId;
            
            var classRoomCreated = _classRoomRepository.RegisterAsync(classRoom);
            await _unitOfWork.CommitAsync();

            return _mapper.Map<ClassRoomResponse>(classRoomCreated);
        }

        public async Task<ClassRoomResponse> UpdateAsync(int id, ClassRoomRequest classRoomRequest)
        {
            var classRoom = await _classRoomRepository.GetByIdAsync(id);
            if(classRoom is null)
                throw new NotFoundException("O id informado não existe");   
        
            if(classRoom.InstructorId != _authService.AuthUser.Id)
                throw new NotAuthorizedException();

            _classRoomRepository.AddPreQuery(query => query.Where(cl=>cl.InstructorId != _authService.AuthUser.Id) );
            var validationResult = await _classRoomValidator.ValidateAsync(classRoomRequest);
            if( ! validationResult.IsValid)
                throw new BadRequestException(validationResult);

            _mapper.Map(classRoomRequest,classRoom);

            var classRoomUpdated =  await _classRoomRepository.UpdateAsync(classRoom);
            await _unitOfWork.CommitAsync();
            return _mapper.Map<ClassRoomResponse>(classRoom);
        }

        public async Task<ClassRoomResponse> DeleteAsync(int id)
        {
            var classRoom = await _classRoomRepository.GetByIdAsync(id);
            if (classRoom is null)
                throw new NotFoundException("O id informado não existe");
        
            if(classRoom.InstructorId != _authService.AuthUser.Id)
                throw new NotAuthorizedException();

            var classRoomDeleted = await _classRoomRepository.RemoveAsync(id);
            await _unitOfWork.CommitAsync();
            
            return _mapper.Map<ClassRoomResponse>(classRoom);  
        }

        public async Task<ActivityResponse> RegisterActivityAsync(int classRoomId, int instructorId, ActivityRequest activityRequest)
        {
            var classRoom = await _classRoomRepository.GetByIdAsync(classRoomId);

            if(classRoom is null)
                throw new NotFoundException("O id informado não existe");

            if(classRoom.InstructorId != instructorId)
                throw new NotAuthorizedException();

            //Validar request

            var activity = _mapper.Map<Activity>(activityRequest);
            var listActivities = classRoom.Activities.ToList();
            listActivities.Add(activity);

            classRoom.Activities = listActivities;

            bool isSucess = await SendEmailToStudents(activity, classRoom);

            await _unitOfWork.CommitAsync();

            return _mapper.Map<ActivityResponse>(activity);

        }

        private async Task<bool> SendEmailToStudents(Activity activity, ClassRoom classRoom)
        {
            string hostEmail = "wesley_play.tj@live.com";
            string hostName = "wesley";
            //TODO: verificar um jeito de colocar isso na user secrets
            var apiKey = "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";

            var client = new SendGridClient(apiKey);


            var msg = new SendGridMessage()
            {
                From = new EmailAddress(hostEmail, hostName),
                Subject = $"Você recebeu uma nova atividade [{activity.Title}]",
                PlainTextContent = $"Sala {classRoom.Name} | {classRoom.Id}  há uma nova uma atividade {activity.Title}, acesse o sistema TeacherBot e tenha acesso"
            };

            
            msg.AddTo(new EmailAddress("ramos.alysonfarias@gmail.com", "Alyson"));
            //msg.AddTo(new EmailAddress("alyson.2020130399@unicap.br", "Kelber"));

            var response = await client.SendEmailAsync(msg);

            // A success status code means SendGrid received the email request and will process it.
            // Errors can still occur when SendGrid tries to send the email. 
            // If email is not received, use this URL to debug: https://app.sendgrid.com/email_activity 
            return response.IsSuccessStatusCode ? true : false;
        }

        public async Task<ActivityResponse> RegisterFileActivity(int classRoomId, int activityId, int instructorId, List<IFormFile> files)
        {
            var classRoom = await _classRoomRepository.GetByIdAsync(classRoomId);

            if (classRoom is null)
                throw new NotFoundException("O id informado não existe");

            if (classRoom.InstructorId != instructorId)
                throw new NotAuthorizedException();

            var activity = classRoom.Activities.SingleOrDefault(at => at.Id == activityId);
            if (activity is null)
                throw new NotFoundException("O id da atividade informado não existe");

            activity.Arquives = GetBase64FromFiles(activity.Arquives.ToList(), files, activityId);

            await _unitOfWork.CommitAsync();
            return _mapper.Map<ActivityResponse>(activity);
        }

        private List<Arquive> GetBase64FromFiles (List<Arquive> initialFiles, List<IFormFile> filesToBeAdd, int activityId)
        {
            int maxMemorySizePerFileBytes = 1048576; // 1mb
            var temporaryArquivesList = initialFiles;

            foreach (var file in filesToBeAdd)
            {
                if (file.Length > 0 && file.Length <= maxMemorySizePerFileBytes)
                {
                    using (var ms = new MemoryStream())
                    {
                        file.CopyTo(ms);
                        var fileBytes = ms.ToArray();
                        string fileB64 = Convert.ToBase64String(fileBytes);

                        var arquive = new Arquive
                        {
                            ActivityId = activityId,
                            CreatedAt = DateTime.Now,
                            UpdatedAt = DateTime.Now,
                            FileTypeId = 1,
                            DataBase64 = fileB64
                        };

                        temporaryArquivesList.Add(arquive);
                    }
                } else if(file.Length > maxMemorySizePerFileBytes)
                {
                    throw new BadRequestException(nameof(file), $"Image size limit is {Utils.ToSize(maxMemorySizePerFileBytes, Utils.SizeUnits.MB)} {Utils.SizeUnits.MB}");
                }
            }
            return temporaryArquivesList;
        }



        public async Task<ActivityResponse> UpdateActivityAsync(int classRoomId,int activityId, int instructorId, ActivityRequest activityRequest)
        {
            var classRoom = await _classRoomRepository.GetByIdAsync(classRoomId);

            if(classRoom is null)
                throw new NotFoundException("O id da sala informado não existe");

            if(classRoom.InstructorId != instructorId)
                throw new NotAuthorizedException();
            
            var activity = classRoom.Activities.SingleOrDefault(at => at.Id == activityId);
            if( activity is null)
                throw new NotFoundException("O id da atividade informado não existe");
                
            //Validar request

            _mapper.Map(activity,activityRequest);

            await _unitOfWork.CommitAsync();
            return _mapper.Map<ActivityResponse>(activity);
        }

        public async Task<ActivityResponse> DeleteActivityAsync(int classRoomId, int activityId, int instructorId)
        {
            var classRoom = await _classRoomRepository.GetByIdAsync(classRoomId);

            if(classRoom is null)
                throw new NotFoundException("O id da sala informado não existe");
            
            if(classRoom.InstructorId != instructorId)
                throw new NotAuthorizedException();

            
            var activity = classRoom.Activities.SingleOrDefault(at => at.Id == activityId);
            if( activity is null)
                throw new NotFoundException("O id da atividade informado não existe");

            
            var listActivities = classRoom.Activities.ToList();
            listActivities.Remove(activity);
            classRoom.Activities = listActivities;

            await _unitOfWork.CommitAsync();
            return _mapper.Map<ActivityResponse>(activity);            
        }
    }
}