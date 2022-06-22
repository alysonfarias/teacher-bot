using FluentValidation;
using Hackathon.Application.DTOS.DeliveryActivity;

namespace Hackathon.Application.Validators
{
    public class DeliveryActivityValidator : AbstractValidator<DeliveryActivityRequest>
    {
        
        public DeliveryActivityValidator()
        {
        }
    }
}