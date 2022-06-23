using FluentValidation;
using Hackathon.Application.DTOS.Activity;

namespace Hackathon.Application.Validators
{
    public class ActivityValidator : AbstractValidator<ActivityRequest>
    {
        public ActivityValidator()
        {
            RuleFor(x => x.Title)
                .NotEmpty()
                .WithMessage("Campo Obrigatório")
                .Length(100)
                .WithMessage("A atividade precisa ter um título");

            RuleFor(x => x.Description)
               .NotEmpty()
               .WithMessage("Campo Obrigatório")
               .Length(250)
               .WithMessage("A atividade precisa ter um título");

            RuleFor(x => x.DueDate)
                .NotEmpty().WithMessage("Campo Obrigatório")
                .LessThan(x => DateTime.Now)
                .WithMessage("Data inválida! A data do vencimento não pode está no passado");
        }
    }
}
