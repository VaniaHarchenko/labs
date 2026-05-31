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

        // [Завдання 7] Додаткові дані здобувача освіти
        public string Specialty { get; set; }
        public int Course { get; set; }

        public List<int> Grades { get; set; } = new List<int>();

        // Оновлений конструктор
        public Student(string fullName, string group, string specialty, int course)
        {
            FullName = fullName;
            Group = group;
            Specialty = specialty;
            Course = course;
        }
    }
}
