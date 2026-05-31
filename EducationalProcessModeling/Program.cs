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
            Console.WriteLine(" Версія 3.0 / Реліз 3                               ");
            Console.WriteLine("=====================================================\n");

            EducationalProcess process = new EducationalProcess();

            // Демонстрація всіх виконаних завдань
            process.ShowEducationForms();
            process.ShowLessonsAndControl();
            process.ShowEducationPlanning();
            process.ShowMethodologicalSupport();
            process.ShowStudentAssessments();

            Console.WriteLine("=====================================================");
            Console.WriteLine("Кінець демонстрації. Натисніть будь-яку клавішу...");
            Console.ReadKey();
        }
    }
}