namespace Hackathon.Application.CustomExceptions
{
    public class NotAuthorizedException : Exception
    {
        public NotAuthorizedException() : base("O usuário não têm permissão")
        {}
    }
}