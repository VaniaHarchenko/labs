using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EducationalProcessModeling
{
    public class Lesson
    {
        public string Title { get; set; } // Лекція, Практика, Лабораторна
        public string ControlType { get; set; } // Іспит, Залік (для Завдання 2)
        public string ScheduleTime { get; set; } // Для Завдання 3 (Планування)

        public Lesson(string title, string controlType)
        {
            Title = title;
            ControlType = controlType;
        }
    }
}
