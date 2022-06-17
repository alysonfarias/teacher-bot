using Hackathon.Domain.Core.Common;

namespace Hackathon.Domain.Models.Enumerations
{
    public class UserRole : Enumeration
    {
        public static UserRole Admin = new (1, nameof(Admin));
        public static UserRole Instructor = new (2, nameof(Instructor));
        public static UserRole Student = new (3, nameof(Student));

        public UserRole()
        {}
        public UserRole(int id, string name) : base (id, name)
        {}
    }
}
