using Hackathon.Domain.Core;

namespace Hackathon.Domain.Models.Enumerations
{
    public class Subject : Enumeration
    {
        public static Subject Portuguese = new(1, nameof(Portuguese));
        public static Subject Mathematics = new(2, nameof(Mathematics));
        public static Subject Programming = new(3, nameof(Programming));
        public static Subject English = new(4, nameof(English));

        public Subject()
        { }
        public Subject(int id, string name) : base(id, name)
        { }
    }
}
