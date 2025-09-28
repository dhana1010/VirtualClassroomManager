namespace VirtualClassroomManager.Models
{
    public class Classroom
    {
        public string Name { get; set; }
        public System.Collections.Generic.List<Student> Students { get; } = new System.Collections.Generic.List<Student>();
        public System.Collections.Generic.List<Assignment> Assignments { get; } = new System.Collections.Generic.List<Assignment>();

        public Classroom(string name)
        {
            Name = name;
        }
    }
}
