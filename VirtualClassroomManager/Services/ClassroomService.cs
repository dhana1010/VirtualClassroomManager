using VirtualClassroomManager.Models;
using System.Collections.Generic;
using System;

namespace VirtualClassroomManager.Services
{
    public class ClassroomService
    {
        private readonly Dictionary<string, Classroom> classrooms = new Dictionary<string, Classroom>();

        public Classroom AddClassroom(string name)
        {
            if (classrooms.ContainsKey(name))
                throw new InvalidOperationException("Classroom " + name + " already exists.");
            var c = new Classroom(name);
            classrooms[name] = c;
            return c;
        }

        public void RemoveClassroom(string name)
        {
            if (!classrooms.Remove(name))
                throw new InvalidOperationException("Classroom " + name + " does not exist.");
        }

        public Classroom GetClassroom(string name)
        {
            Classroom c;
            if (!classrooms.TryGetValue(name, out c))
                throw new InvalidOperationException("Classroom " + name + " does not exist.");
            return c;
        }

        public IEnumerable<Classroom> ListClassrooms() { return classrooms.Values; }
    }
}
