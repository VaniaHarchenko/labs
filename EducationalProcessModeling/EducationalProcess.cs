using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EducationalProcessModeling
{
    public class EducationalProcess
    {
        public List<EducationForm> EducationForms { get; set; } = new List<EducationForm>();
        public List<Lesson> Lessons { get; set; } = new List<Lesson>();
        public List<Student> Students { get; set; } = new List<Student>();
        public List<Teacher> Teachers { get; set; } = new List<Teacher>();

        public string MethodologicalSupport { get; set; } = "Стандартне забезпечення (Реліз 1)";
        public double QualityScore { get; set; } = 100.0;

        public EducationalProcess()
        {
            // [Завдання 1]
            EducationForms.Add(new EducationForm("Денна", 9, "Максимум взаємодії з викладачами, регулярні заняття."));
            EducationForms.Add(new EducationForm("Заочна", 2, "Самостійне навчання з короткими сесіями вичитки лекцій."));
            EducationForms.Add(new EducationForm("Дистанційна", 9, "Навчання через онлайн-платформи в синхронному/асинхронному режимі."));

            // [Завдання 2] Ініціалізація занять та видів контролю
            Lessons.Add(new Lesson("Вища математика (Лекція)", "Залік"));
            Lessons.Add(new Lesson("Об'єктно-орієнтоване програмування (Практика)", "Іспит"));
            Lessons.Add(new Lesson("Фізика (Лабораторна)", "Залік"));

            // [Завдання 3] Планування (задаємо час у розкладі для цих занять)
            Lessons[0].ScheduleTime = "Понеділок, 08:30";
            Lessons[1].ScheduleTime = "Вівторок, 10:15";
            Lessons[2].ScheduleTime = "Середа, 12:00";

            // [Завдання 4] Науково-методичне забезпечення для занять
            Lessons[0].MethodologicalMaterials.Add("Підручник 'Вища математика для інженерів' (2023)");
            Lessons[0].MethodologicalMaterials.Add("Методичні вказівки до практичних робіт №1-5");

            Lessons[1].MethodologicalMaterials.Add("Вивчення курсу ВООП");
            Lessons[1].MethodologicalMaterials.Add("Конспект лекцій на GitHub викладача");

            Lessons[2].MethodologicalMaterials.Add("Інструкції до лабораторних робіт у Virtual Lab");
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

        // Метод для виводу Завдання 2
        public void ShowLessonsAndControl()
        {
            Console.WriteLine("=== [ЗАВДАННЯ 2] Види навчальних занять і контролю ===");
            foreach (var lesson in Lessons)
            {
                Console.WriteLine($"• Заняття: {lesson.Title} | Форма контролю: {lesson.ControlType}");
            }
            Console.WriteLine();
        }

        // Метод для виводу Завдання 3
        public void ShowEducationPlanning()
        {
            Console.WriteLine("=== [ЗАВДАННЯ 3] Планування освітнього процесу (Розклад) ===");
            foreach (var lesson in Lessons)
            {
                // 
                Console.WriteLine($"[План] {lesson.ScheduleTime} -> {lesson.Title}");
            }
            Console.WriteLine();
        }
        public void ShowMethodologicalSupport()
        {
            Console.WriteLine("=== [ЗАВДАННЯ 4] Науково-методичне забезпечення освітнього процесу ===");
            foreach (var lesson in Lessons)
            {
                // Замінили книжку на простий покажчик [Матеріали]
                Console.WriteLine($"[Матеріали] Дисципліна: {lesson.Title}");
                foreach (var material in lesson.MethodologicalMaterials)
                {
                    Console.WriteLine($"   - {material}");
                }
            }
            Console.WriteLine();
        }
    }
}
