namespace Hackathon.Domain.Models
{
    public class StudentActivity
    {
        public string DataBase64 { get; set; }
        public int StudentId { get; set; }
        public Student Student { get; set; }
        public int ActivityId { get; set; }
        public Activity Activity { get; set; }
    }
}