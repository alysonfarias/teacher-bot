using FluentValidation;
using Hackathon.Application.DTOS.Instructor;
using Hackathon.Application.Validators.Base;
using Hackathon.Domain.Core.Common;
using Hackathon.Domain.Interfaces;
using Hackathon.Domain.Models.Enumerations;
using Microsoft.EntityFrameworkCore;

namespace Hackathon.Application.Validators
{
    public class InstructorValidator : BaseUserRequestValidator<InstructorRequest>
    {

        public InstructorValidator(IInstructorRepository _instructorRepository)
        :base()
        {
            RuleFor(ir=> ir.Username)
                .MustAsync((username,cancellationToken) =>  _instructorRepository.Query().AsNoTracking().AllAsync(sr => sr.Username != username,cancellationToken))
                .WithMessage("Username já presente no banco");
            
            RuleFor(ir => ir.Email)
                .MustAsync((email,cancellationToken)=> _instructorRepository.Query().AsNoTracking().AllAsync(us=> us.Email != email,cancellationToken))
                .WithMessage("Email já presente no banco");

            RuleFor(ir => ir.UserRoleId)
                .Must(type => Enumeration.GetAll<Subject>().Any(subject => subject.Id==type))
                .WithMessage("Disciplina invalida");
        

        }
    }
}