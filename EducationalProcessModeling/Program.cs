using System;

namespace EducationalProcessModeling
{
    class Program
    {
        static void Main(string[] args)
        {
            // Встановлюємо кодування для коректного відображення української мови в консолі
            Console.OutputEncoding = System.Text.Encoding.UTF8;

            Console.WriteLine("=====================================================");
            Console.WriteLine(" Моделювання бізнес-процесів освітнього процесу ВНЗ ");
            Console.WriteLine("=====================================================\n");

            // Створюємо головний об'єкт моделювання
            EducationalProcess process = new EducationalProcess();

            // Викликаємо функціонал РЕЛІЗУ 1 (Завдання 1)
            process.ShowEducationForms();

            Console.WriteLine("=====================================================");
            Console.WriteLine("Кінець демонстрації Релізу 1. Натисніть будь-яку клавішу...");
            Console.ReadKey();
        }
    }
}