using Hackathon.Domain.Core.Common;
using Hackathon.Domain.Models.Enumerations;

namespace Hackathon.Domain.Core
{
    public class User : Register
    {
        public int UserRoleId { get; set; }
        public UserRole UserRole { get; set; }
        public string Name { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public string Password{ get; set; }
        public DateTime BirthDate { get; set; }
    }
}
