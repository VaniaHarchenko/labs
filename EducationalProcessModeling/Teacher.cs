using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EducationalProcessModeling
{
    public class Teacher
    {
        public string Name { get; set; }
        public string Department { get; set; }

        // [Завдання 6] Дані про підвищення кваліфікації
        public List<string> QualificationCourses { get; set; } = new List<string>();

        public Teacher(string name, string department)
        {
            Name = name;
            Department = department;
        }
    }
}
