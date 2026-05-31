using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EducationalProcessModeling
{
    public class Student
    {
        public string FullName { get; set; }
        public string Group { get; set; }
        public string Qualification { get; set; } // Для Завдання 6
        public bool IsAcademicMobility { get; set; } // Для Завдання 9
        public List<int> Grades { get; set; } = new List<int>(); // Для Завдання 5

        public Student(string fullName, string group)
        {
            FullName = fullName;
            Group = group;
        }
    }
}
