namespace Hackathon.Application.CustomExceptions
{
    public class NotAuthorizedException : Exception
    {
        public NotAuthorizedException() : base("O usuario nao tem permissao")
        {}
    }
}