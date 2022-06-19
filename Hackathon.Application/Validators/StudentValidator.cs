using System.Text.RegularExpressions;
using FluentValidation;
using Hackathon.Application.DTOS.Student;
using Hackathon.Application.Validators.Base;
using Hackathon.Domain.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Hackathon.Application.Validators
{
    public class StudentValidator : BaseUserRequestValidator<StudentRequest>
    {   
        public StudentValidator(IStudentRepository _studentRepository)
        :base()
        {
            RuleFor(sr=> sr.Username)
                .MustAsync((username,cancellationToken) =>  _studentRepository.Query().AsNoTracking().AllAsync(sr => sr.Username != username,cancellationToken))
                .WithMessage("Username já presente no banco");
            
            RuleFor(sr => sr.Email)
                .MustAsync((email,cancellationToken)=> _studentRepository.Query().AsNoTracking().AllAsync(us=> us.Email != email,cancellationToken))
                .WithMessage("Email já presente no banco");

            RuleFor(sr => sr.ResponsiblePhone)
                .Must(rp => PhoneIsValid(rp))
                .WithMessage("O formato do telefone deve ser do tipo : (xx) x?xxxx-xxxx");

        }

        public static bool PhoneIsValid(string FormattedPhone)
        {
            return new Regex(@"^\(?[1-9]{2}\)? ?(?:[2-8]|9[1-9])[0-9]{3}\-?[0-9]{4}$").IsMatch(FormattedPhone);
        }
    }
}