namespace Hackathon.Application.DTOS.Common
{
    public class UserViewModel
    {
        public int UserRoleId { get; set; }
        public string Name { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public string Password{ get; set; }
        public DateTime BirthDate { get; set; }
    }
}