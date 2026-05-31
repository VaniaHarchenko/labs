using System;

namespace EducationalProcessModeling
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            EducationalProcess process = new EducationalProcess();
            bool exit = false;

            while (!exit)
            {
                Console.Clear();
                Console.WriteLine("=====================================================");
                Console.WriteLine(" Моделювання бізнес-процесів освітнього процесу ВНЗ ");
                Console.WriteLine(" Версія: 4.1 (Розробка Релізу 5)                     ");
                Console.WriteLine("=====================================================");
                Console.WriteLine("1. [Завдання 1] Форми організації навчання");
                Console.WriteLine("2. [Завдання 2] Види занять та контролю");
                Console.WriteLine("3. [Завдання 3] Планування (Розклад)");
                Console.WriteLine("4. [Завдання 4] Науково-методичне забезпечення");
                Console.WriteLine("5. [Завдання 5] Оцінювання результатів навчання");
                Console.WriteLine("6. [Завдання 6] Підвищення кваліфікації викладачів");
                Console.WriteLine("7. [Завдання 7] Детальні дані здобувачів освіти");
                Console.WriteLine("8. [Завдання 8] Взаємодія учасників процесу (Нове!)");
                Console.WriteLine("0. Вихід із програми");
                Console.WriteLine("=====================================================");
                Console.Write("Виберіть пункт меню: ");

                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        process.ShowEducationForms();
                        break;
                    case "2":
                        process.ShowLessonsAndControl();
                        break;
                    case "3":
                        process.ShowEducationPlanning();
                        break;
                    case "4":
                        process.ShowMethodologicalSupport();
                        break;
                    case "5":
                        process.ShowStudentAssessments();
                        break;
                    case "6":
                        process.ShowTeacherQualifications();
                        break;
                    case "7":
                        process.ShowDetailedStudents();
                        break;
                    case "8":
                        process.ShowParticipantsInteraction();
                        break;
                    case "0":
                        exit = true;
                        Console.WriteLine("Програму завершено. До побачення!");
                        continue;
                    default:
                        Console.WriteLine("\nНекоректний вибір! Спробуйте ще раз.");
                        break;
                }

                Console.WriteLine("Натисніть будь-яку клавішу для повернення в меню...");
                Console.ReadKey();
            }
        }
    }
}