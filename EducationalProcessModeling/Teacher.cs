using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EducationalProcessModeling
{
    public class Teacher
    {
        public string FullName { get; set; }
        public string Position { get; set; } // Професор, доцент тощо
        public string Department { get; set; }

        public Teacher(string fullName, string position, string department)
        {
            FullName = fullName;
            Position = position;
            Department = department;
        }
    }
}
