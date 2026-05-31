using System;

namespace EducationalProcessModeling
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;

            Console.WriteLine("=====================================================");
            Console.WriteLine(" Моделювання бізнес-процесів освітнього процесу ВНЗ ");
            Console.WriteLine("  Версія: 2.0 (Реліз 2)                           "); // Оце ми додали!
            Console.WriteLine("=====================================================\n");

            EducationalProcess process = new EducationalProcess();

            // Демонстрація Завдання 1
            process.ShowEducationForms();

            // Демонстрація завдань Релізу 2
            process.ShowLessonsAndControl();
            process.ShowEducationPlanning();

            Console.WriteLine("=====================================================");
            Console.WriteLine("Кінець демонстрації Релізу 2. Натисніть будь-яку клавішу...");
            Console.ReadKey();
        }
    }
}