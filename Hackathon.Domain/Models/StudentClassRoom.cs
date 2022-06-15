namespace Hackathon.Domain.Models
{
    public class StudentClassRoom
    {
        public ClassRoom ClassRoom { get; set; }
        public int ClassRoomId { get; set; }
        public Student  Student { get; set; }
        public int  StudentId { get; set; }
    }
}
