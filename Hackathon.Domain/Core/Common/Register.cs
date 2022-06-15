namespace Hackathon.Domain.Core.Common
{
    public abstract class Register
    {
        public int Id { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdateAt { get; set; }
    }
}
