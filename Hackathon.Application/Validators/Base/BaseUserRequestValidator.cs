using FluentValidation;
using Hackathon.Application.DTOS.Common;
using Hackathon.Domain.Core.Common;
using Hackathon.Domain.Interfaces.Base.Common;
using Hackathon.Domain.Models.Core;
using Hackathon.Domain.Models.Enumerations;
using Microsoft.EntityFrameworkCore;

namespace Hackathon.Application.Validators.Base
{
    public class BaseUserRequestValidator<T> : AbstractValidator<T>
    where T: UserRequest
    {
        public BaseUserRequestValidator()
        {
            RuleFor(ur => ur.Name)
                .NotEmpty().WithMessage("Nome não pode ser vazio")
                .MaximumLength(200).WithMessage("Nome maior que o valor de 200 caracteres");

            RuleFor(ur => ur.Username)
                .NotEmpty().WithMessage("Username não pode ser vazio")
                .MaximumLength(200).WithMessage("Username não pode ser vazio");

            RuleFor(ur => ur.Email)
                .NotEmpty().WithMessage("Email não pode ser vazio")
                .EmailAddress().WithMessage("Insira um email válido");
            
            RuleFor(ur => ur.BirthDate)
                .LessThan(p => DateTime.Now).WithMessage("A data deve estar no passado");

            RuleFor(ur => ur.UserRoleId)
                .Must(type => Enumeration.GetAll<UserRole>().Any(userRole => userRole.Id==type))
                .WithMessage("Tipo de usuario invalido");
        }
    }
}