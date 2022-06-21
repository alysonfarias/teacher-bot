using FluentValidation;
using Hackathon.Application.DTOS.Instructor;
using Hackathon.Application.Validators.Base;
using Hackathon.Domain.Core.Common;
using Hackathon.Domain.Interfaces;
using Hackathon.Domain.Models;
using Hackathon.Domain.Models.Enumerations;

namespace Hackathon.Application.Validators
{
    public class InstructorValidator : BaseUserRequestValidator<InstructorRequest,Instructor>
    {

        public InstructorValidator(IInstructorRepository _instructorRepository)
        :base(_instructorRepository)
        {
            RuleFor(ir => ir.UserRoleId)
                .Must(type => Enumeration.GetAll<Subject>().Any(subject => subject.Id==type))
                .WithMessage("Disciplina invalida");
        }
    }
}