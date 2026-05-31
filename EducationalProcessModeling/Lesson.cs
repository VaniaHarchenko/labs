using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EducationalProcessModeling
{
    public class Lesson
    {
        public string Title { get; set; }
        public string ControlType { get; set; }
        public string ScheduleTime { get; set; }

        // [Завдання 4] Список методичних матеріалів для заняття
        public List<string> MethodologicalMaterials { get; set; } = new List<string>();

        public Lesson(string title, string controlType)
        {
            Title = title;
            ControlType = controlType;
        }
    }
}
