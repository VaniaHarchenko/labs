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

        public string MethodologicalSupport { get; set; } = "Стандартне забезпечення";
        public double QualityScore { get; set; } = 100.0;

        public EducationalProcess()
        {
            // [Завдання 1] Форми організації
            EducationForms.Add(new EducationForm("Денна", 9, "Максимум взаємодії з викладачами, регулярні заняття."));
            EducationForms.Add(new EducationForm("Заочна", 2, "Самостійне навчання з короткими сесіями вичитки лекцій."));
            EducationForms.Add(new EducationForm("Дистанційна", 9, "Навчання через онлайн-платформи в синхронному/асинхронному режимі."));

            // [Завдання 2] Види навчальних занять і контролю
            Lessons.Add(new Lesson("Вища математика (Лекція)", "Залік"));
            Lessons.Add(new Lesson("Об'єктно-орієнтоване програмування (Практика)", "Іспит"));
            Lessons.Add(new Lesson("Фізика (Лабораторна)", "Залік"));

            // [Завдання 3] Планування (Розклад)
            Lessons[0].ScheduleTime = "Понеділок, 08:30";
            Lessons[1].ScheduleTime = "Вівторок, 10:15";
            Lessons[2].ScheduleTime = "Середа, 12:00";

            // [Завдання 4] Науково-методичне забезпечення
            Lessons[0].MethodologicalMaterials.Add("Підручник 'Вища математика для інженерів' (2023)");
            Lessons[0].MethodologicalMaterials.Add("Методичні вказівки до практичних робіт 1-5");
            Lessons[1].MethodologicalMaterials.Add("Силабус курсу ВООП");
            Lessons[1].MethodologicalMaterials.Add("Конспект лекцій на GitHub викладача");
            Lessons[2].MethodologicalMaterials.Add("Інструкції до лабораторних робіт у Virtual Lab");

            // [Завдання 6] Підвищення кваліфікації викладачів
            Teacher teacher1 = new Teacher("Проф. Захаров О.М.", "Кафедра Інженерії ПЗ");
            teacher1.QualificationCourses.Add("Курс 'Сучасні методи ВООП у .NET8' (2025, 180 год)");
            teacher1.QualificationCourses.Add("Стажування в IT-компанії SoftServe");

            Teacher teacher2 = new Teacher("Доц. Коваленко В.П.", "Кафедра Вищої Математики");
            teacher2.QualificationCourses.Add("Воркшоп 'Data Science та статистика в освіті' (2024)");

            Teachers.Add(teacher1);
            Teachers.Add(teacher2);

            // [Завдання 7] Здобувачі освіти (оновлені дані)
            Student student1 = new Student("Іваненко Іван", "КН-21", "Комп'ютерні науки", 2);
            student1.Grades.AddRange(new int[] { 95, 88, 90 });

            Student student2 = new Student("Петренко Ольга", "КН-21", "Комп'ютерні науки", 2);
            student2.Grades.AddRange(new int[] { 82, 75, 91 });

            Students.Add(student1);
            Students.Add(student2);
        }

        public void ShowEducationForms()
        {
            Console.WriteLine("=== [ЗАВДАННЯ 1] Форми організації освітнього процесу ===");
            foreach (var form in EducationForms) form.DisplayInfo();
        }

        public void ShowLessonsAndControl()
        {
            Console.WriteLine("=== [ЗАВДАННЯ 2] Види навчальних занять і контролю ===");
            foreach (var lesson in Lessons) Console.WriteLine($"* Заняття: {lesson.Title} | Форма контролю: {lesson.ControlType}");
            Console.WriteLine();
        }

        public void ShowEducationPlanning()
        {
            Console.WriteLine("=== [ЗАВДАННЯ 3] Планування освітнього процесу (Розклад) ===");
            foreach (var lesson in Lessons) Console.WriteLine($"[План] {lesson.ScheduleTime} -> {lesson.Title}");
            Console.WriteLine();
        }

        public void ShowMethodologicalSupport()
        {
            Console.WriteLine("=== [ЗАВДАННЯ 4] Науково-методичне забезпечення освітнього процесу ===");
            foreach (var lesson in Lessons)
            {
                Console.WriteLine($"[Матеріали] Дисципліна: {lesson.Title}");
                foreach (var material in lesson.MethodologicalMaterials) Console.WriteLine($"   - {material}");
            }
            Console.WriteLine();
        }

        public void ShowStudentAssessments()
        {
            Console.WriteLine("=== [ЗАВДАННЯ 5] Оцінювання результатів навчання ===");
            foreach (var student in Students)
            {
                Console.Write($"[Студент] {student.FullName} | Оцінки: {string.Join(", ", student.Grades)}");
                double average = student.Grades.Count > 0 ? student.Grades.Average() : 0;
                Console.WriteLine($" | Середній бал: {average:F1}");
            }
            Console.WriteLine();
        }

        // [Завдання 6] Вивід кваліфікації викладачів
        public void ShowTeacherQualifications()
        {
            Console.WriteLine("=== [ЗАВДАННЯ 6] Підвищення кваліфікації працівників ===");
            foreach (var teacher in Teachers)
            {
                Console.WriteLine($"[Викладач] {teacher.Name} ({teacher.Department})");
                foreach (var course in teacher.QualificationCourses) Console.WriteLine($"   * {course}");
            }
            Console.WriteLine();
        }

        // [Завдання 7] Вивід детальної інформації про студентів
        public void ShowDetailedStudents()
        {
            Console.WriteLine("=== [ЗАВДАННЯ 7] Здобувачі освіти (Студенти) ===");
            foreach (var student in Students)
            {
                Console.WriteLine($"[Здобувач] {student.FullName} | Спеціальність: {student.Specialty} | {student.Course}-й курс | Група: {student.Group}");
            }
            Console.WriteLine();
        }
    }
}
