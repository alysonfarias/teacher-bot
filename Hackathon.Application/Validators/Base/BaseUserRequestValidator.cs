using FluentValidation;
using Hackathon.Application.DTOS.Common;
using Hackathon.Domain.Core.Common;
using Hackathon.Domain.Interfaces.Base.Common;
using Hackathon.Domain.Models.Core;
using Hackathon.Domain.Models.Enumerations;
using Microsoft.EntityFrameworkCore;
using System.Text.RegularExpressions;

namespace Hackathon.Application.Validators.Base
{
    public class BaseUserRequestValidator<T,U> : AbstractValidator<T>
    where T: UserRequest
    where U : User
    {
        public BaseUserRequestValidator(IUserRepository<U> _userRepository)
        {
            RuleFor(ur => ur.Name)
                .NotEmpty().WithMessage("Nome não pode ser vazio")
                .MaximumLength(200).WithMessage("Nome maior que o valor de 200 caracteres");

            RuleFor(ur => ur.Username)
                .NotEmpty().WithMessage("Username não pode ser vazio")
                .MaximumLength(200).WithMessage("Username não pode ser vazio");
                
            RuleFor(ir=> ir.Username)
                .MustAsync((username,cancellationToken) =>  _userRepository.Query().AsNoTracking().AllAsync(sr => sr.Username != username,cancellationToken))
                .WithMessage("Username já presente no banco");
            

            RuleFor(ur => ur.Email)
                .NotEmpty().WithMessage("Email não pode ser vazio")
                .EmailAddress().WithMessage("Insira um email válido");
            
            RuleFor(ir => ir.Email)
                .MustAsync((email,cancellationToken)=> _userRepository.Query().AsNoTracking().AllAsync(us=> us.Email != email,cancellationToken))
                .WithMessage("Email já presente no banco");
            
            RuleFor(ur => ur.BirthDate)
                .LessThan(p => DateTime.Now).WithMessage("A data deve estar no passado");

            RuleFor(ur => ur.UserRoleId)
                .Must(type => Enumeration.GetAll<UserRole>().Any(userRole => userRole.Id==type))
                .WithMessage("Tipo de usuario invalido");

            RuleFor(ur => ur.Password)
                .NotEmpty()
                .WithMessage("Campo Obrigatorio")
                .Must(X => isValidPassword(X))
                .WithMessage("Senha num formato invalido!");
        }
        private static bool isValidPassword(string password)
        {

            var hasNumber = new Regex(@"[0-9]+");
            var hasUpperChar = new Regex(@"[A-Z]+");
            var hasSymbols = new Regex(@"[!@#$%^&*()_+=\[{\]};:<>|./?,-]");

            return hasNumber.IsMatch(password) && hasUpperChar.IsMatch(password) && !(hasSymbols.IsMatch(password));
        }
    }
}