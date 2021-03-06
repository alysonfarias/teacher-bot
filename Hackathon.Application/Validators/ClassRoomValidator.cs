using FluentValidation;
using Hackathon.Application.DTOS.ClassRoom;
using Hackathon.Domain.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Hackathon.Application.Validators
{
    public class ClassRoomValidator : AbstractValidator<ClassRoomRequest>
    {
        public ClassRoomValidator
        (
            IClassRoomRepository _classRoomRepository 
        )
        {
            RuleFor(cr => cr.Name)
                .NotEmpty()
                .WithMessage("Campo Obrigatorio")
                .MustAsync((name,cancellationToken) => _classRoomRepository.Query().AsNoTracking().AllAsync(classroom=> classroom.Name!=name,cancellationToken))
                .WithMessage("Nome já cadastrado no sitema");

            RuleFor(cr => cr.Description )
                .NotEmpty()
                .WithMessage("Campo Obrigatorio")
                .MaximumLength(500)
                .WithMessage("Tamanho da descrição excedendo 500");
        }
    }
}