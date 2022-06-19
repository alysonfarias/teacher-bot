namespace Hackathon.Application.Exceptions
{
    public class NotAuthorized : Exception
    {
        public NotAuthorizedException() : base("O usuario nao tem permissao")
        {}
    }
}