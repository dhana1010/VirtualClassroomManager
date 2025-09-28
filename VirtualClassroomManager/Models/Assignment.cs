namespace VirtualClassroomManager.Models
{
    public class Assignment
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public System.DateTime ScheduledAt { get; set; } = System.DateTime.UtcNow;
        public System.Collections.Generic.List<Submission> Submissions { get; } = new System.Collections.Generic.List<Submission>();
    }
}
