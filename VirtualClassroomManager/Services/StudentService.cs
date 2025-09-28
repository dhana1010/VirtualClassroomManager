using VirtualClassroomManager.Models;
using System;
using System.Linq;

namespace VirtualClassroomManager.Services
{
    public class StudentService
    {
        public Student AddStudent(Classroom classroom, string studentId)
        {
            if (classroom.Students.Any(stu => stu.Id == studentId))
                throw new InvalidOperationException("Student " + studentId + " already enrolled.");

            var student = new Student(studentId);
            classroom.Students.Add(student);
            return student;
        }

    }
}
