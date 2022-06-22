

using Hackathon.Application.DTOS.Enumerations;

namespace Hackathon.Application.DTOS.Common
{
    public class UserResponse : RegisterViewModel
    {
        public string Name { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public DateTime BirthDate { get; set; }
        public UserRoleResponse UserRole { get; set; }
    }
}
