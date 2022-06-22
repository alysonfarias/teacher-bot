using FluentValidation;
using Hackathon.Application.DTOS.Activity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hackathon.Application.Validators
{
    public class ActivityValidator : AbstractValidator<ActivityRequest>
    {
        public ActivityValidator()
        {
            RuleFor(x => x.Title)
                .NotEmpty()
                .WithMessage("Campo Obrigatorio")
                .Length(100)
                .WithMessage("A atividade precisa ter um titulo");

            RuleFor(x => x.Description)
               .NotEmpty()
               .WithMessage("Campo Obrigatorio")
               .Length(250)
               .WithMessage("A atividade precisa ter um titulo");

            RuleFor(x => x.DueDate)
                .NotEmpty().WithMessage("Campo Obrigatorio")
                .LessThan(x => DateTime.Now)
                .WithMessage("Data invalida! A data do vencimento não pode está no passado");
        }

    }
}
