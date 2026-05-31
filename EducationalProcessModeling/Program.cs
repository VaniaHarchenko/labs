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
            Console.WriteLine("=====================================================\n");

            EducationalProcess process = new EducationalProcess();

            // Демонстрація Завдання 1
            process.ShowEducationForms();

            // Демонстрація нових завдань (Коміт 1)
            process.ShowLessonsAndControl();
            process.ShowEducationPlanning();

            Console.WriteLine("=====================================================");
            Console.WriteLine("Кінець демонстрації проміжних завдань. Натисніть будь-яку клавішу...");
            Console.ReadKey();
        }
    }
}