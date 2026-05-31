using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EducationalProcessModeling
{
    public class EducationalProcess
    {
        // Списки для збереження об'єктів моделювання
        public List<EducationForm> EducationForms { get; set; } = new List<EducationForm>();
        public List<Lesson> Lessons { get; set; } = new List<Lesson>();
        public List<Student> Students { get; set; } = new List<Student>();
        public List<Teacher> Teachers { get; set; } = new List<Teacher>();

        // Поля для Завдань 4, 10
        public string MethodologicalSupport { get; set; } = "Стандартне забезпечення (Реліз 1)";
        public double QualityScore { get; set; } = 100.0;

        public EducationalProcess()
        {
            // Ініціалізація даних для ЗАВДАННЯ 1 (Реліз 1)
            EducationForms.Add(new EducationForm("Денна", 9, "Максимум взаємодії з викладачами, регулярні заняття."));
            EducationForms.Add(new EducationForm("Заочна", 2, "Самостійне навчання з короткими сесіями вичитки лекцій."));
            EducationForms.Add(new EducationForm("Дистанційна", 9, "Навчання через онлайн-платформи в синхронному/асинхронному режимі."));
        }

        // Метод для виводу Завдання 1
        public void ShowEducationForms()
        {
            Console.WriteLine("=== [ЗАВДАННЯ 1] Форми організації освітнього процесу ===");
            foreach (var form in EducationForms)
            {
                form.DisplayInfo();
            }
        }
    }
}
