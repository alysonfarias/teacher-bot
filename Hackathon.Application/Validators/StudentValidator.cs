using System.Text.RegularExpressions;
using FluentValidation;
using Hackathon.Application.DTOS.Student;
using Hackathon.Application.Validators.Base;
using Hackathon.Domain.Interfaces.Repositories;
using Hackathon.Domain.Models;

namespace Hackathon.Application.Validators
{
    public class StudentValidator : BaseUserRequestValidator<StudentRequest,Student>
    {   
        public StudentValidator(IStudentRepository _studentRepository)
        :base(_studentRepository)
        {
            RuleFor(sr => sr.ResponsiblePhone)
                .Must(rp => Utils.PhoneIsValid(rp))
                .WithMessage("O formato do telefone deve ser do tipo : (xx) x?xxxx-xxxx");
        }
    }
}