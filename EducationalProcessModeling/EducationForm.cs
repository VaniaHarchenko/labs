using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EducationalProcessModeling
{
    public class EducationForm
    {
        public string Name { get; set; } // Денна, Заочна, Дистанційна
        public int DurationInMonths { get; set; } // Тривалість навчання на рік
        public string Description { get; set; }

        public EducationForm(string name, int duration, string description)
        {
            Name = name;
            DurationInMonths = duration;
            Description = description;
        }

        public void DisplayInfo()
        {
            Console.WriteLine($"• Форма навчання: {Name}");
            Console.WriteLine($"  Тривалість семестрів/занять на рік (в місяцях): {DurationInMonths}");
            Console.WriteLine($"  Особливість: {Description}\n");
        }
    }
}
