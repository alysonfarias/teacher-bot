using Hackathon.Domain.Models.Enumerations;

namespace Hackathon.Application.DTOS.Common
{
    public class UserResponse
    {
        public UserRoleResponse UserRole { get; set; }
        public string Name { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public DateTime BirthDate { get; set; }
    }
}
