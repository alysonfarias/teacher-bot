using FluentValidation.Results;

namespace Hackathon.Application.CustomExceptions
{
    public class BadRequestException : Exception
    {
        public List<ValidationFailure> Errors { get; set; } = new List<ValidationFailure>();
        
        public BadRequestException(string propertie, string errorMessage) : this()
        {
            Errors.Add(new ValidationFailure(propertie, errorMessage));
        }

        public BadRequestException(ValidationResult validationResult) : this()
        {
            Errors = validationResult.Errors;
        }

        public BadRequestException() : base("Requisição inválida.")
        {}
    }
}