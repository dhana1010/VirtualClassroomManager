namespace VirtualClassroomManager.Models
{
    public class Submission
    {
        public string StudentId { get; set; }
        public string Content { get; set; }
        public System.DateTime SubmittedAt { get; set; } = System.DateTime.UtcNow;
    }
}
