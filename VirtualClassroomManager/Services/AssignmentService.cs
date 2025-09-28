using VirtualClassroomManager.Models;
using System;
using System.Linq;

namespace VirtualClassroomManager.Services
{
    public class AssignmentService
    {
        private int nextId = 1;

        public Assignment ScheduleAssignment(Classroom classroom, string title, string description)
        {
            var assignment = new Assignment { Id = nextId++, Title = title, Description = description };
            classroom.Assignments.Add(assignment);
            return assignment;
        }

        public Submission SubmitAssignment(Classroom classroom, string studentId, string assignmentTitle, string content)
        {
            var assignment = classroom.Assignments.FirstOrDefault(a => a.Title == assignmentTitle);
            if (assignment == null) throw new InvalidOperationException("Assignment not found.");
            var submission = new Submission { StudentId = studentId, Content = content };
            assignment.Submissions.Add(submission);
            return submission;
        }
    }
}
