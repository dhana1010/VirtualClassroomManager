using System;
using VirtualClassroomManager.Models;
using VirtualClassroomManager.Services;

namespace VirtualClassroomManager
{
    public class VCM
    {
        private readonly ClassroomService classroomService = new ClassroomService();
        private readonly StudentService studentService = new StudentService();
        private readonly AssignmentService assignmentService = new AssignmentService();

        public void Run()
        {
            Console.WriteLine("-- Virtual Classroom Manager --");
            PrintHelp();
            string line;
            while ((line = Console.ReadLine()) != null)
            {
                if (line.Trim().Equals("exit", StringComparison.OrdinalIgnoreCase)) break;
                try
                {
                    HandleCommand(line);
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error: " + ex.Message);
                }
            }
        }

        private void PrintHelp()
        {
            Console.WriteLine("Commands:");
            Console.WriteLine(" add_classroom <className>");
            Console.WriteLine(" remove_classroom <className>");
            Console.WriteLine(" list_classrooms");
            Console.WriteLine(" add_student <studentId> <className>");
            Console.WriteLine(" list_students <className>");
            Console.WriteLine(" schedule_assignment <className> <title> | <description>");
            Console.WriteLine(" submit_assignment <studentId> <className> <assignmentTitle> | <submissionContent>");
            Console.WriteLine(" exit");
        }

        private void HandleCommand(string line)
        {
            var parts = line.Split(new[] { ' ' }, 2);
            var command = parts[0];
            var args = parts.Length > 1 ? parts[1] : string.Empty;

            switch (command)
            {
                case "add_classroom":
                    var classroom = classroomService.AddClassroom(args);
                    Console.WriteLine("Classroom " + classroom.Name + " has been created.");
                    break;

                case "remove_classroom":
                    classroomService.RemoveClassroom(args);
                    Console.WriteLine("Classroom " + args + " removed.");
                    break;

                case "list_classrooms":
                    foreach (var c in classroomService.ListClassrooms())
                        Console.WriteLine(c.Name);
                    break;

                case "add_student":
                    {
                        var tokens = args.Split(new[] { ' ' }, 2);
                        var sId = tokens[0];
                        var cName = tokens[1];
                        var c = classroomService.GetClassroom(cName);
                        studentService.AddStudent(c, sId);
                        Console.WriteLine("Student " + sId + " has been enrolled in " + cName + ".");
                        break;
                    }

                case "list_students":
                    {
                        var c = classroomService.GetClassroom(args);
                        foreach (var s in c.Students)
                            Console.WriteLine(s.Id);
                        break;
                    }

                case "schedule_assignment":
                    {
                        var firstSplit = args.Split(new[] { ' ' }, 2);
                        var cName = firstSplit[0];
                        var remainder = firstSplit[1].Split('|');
                        var title = remainder[0].Trim();
                        var desc = remainder.Length > 1 ? remainder[1].Trim() : "";
                        var c = classroomService.GetClassroom(cName);
                        assignmentService.ScheduleAssignment(c, title, desc);
                        Console.WriteLine("Assignment for " + cName + " has been scheduled.");
                        break;
                    }

                case "submit_assignment":
                    {
                        var tokens = args.Split(new[] { ' ' }, 3);
                        var sId = tokens[0];
                        var cName = tokens[1];
                        var remainder = tokens[2].Split('|');
                        var aTitle = remainder[0].Trim();
                        var content = remainder.Length > 1 ? remainder[1].Trim() : "";
                        var c = classroomService.GetClassroom(cName);
                        assignmentService.SubmitAssignment(c, sId, aTitle, content);
                        Console.WriteLine("Assignment submitted by Student " + sId + " in " + cName + ".");
                        break;
                    }

                default:
                    Console.WriteLine("Unknown command");
                    break;
            }
        }
    }
}
