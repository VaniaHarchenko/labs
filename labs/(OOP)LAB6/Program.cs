using System;
using System.Collections.Generic;
using System.IO;

namespace _OOP_LAB6
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;

            // створюємо людей (агрегація)
            var group = new List<Person> { new Person("Юрко"), new Person("Олександр") };

            // створюємо об'єкт (спадкування)
            var myTravelCar = new SmartMobileShower("Ivan мобіль", group);

            //події (делегати)
            myTravelCar.OnSystemMessage += (msg) =>
            {
                Console.ForegroundColor = ConsoleColor.Magenta;
                Console.WriteLine($"[БОРТОВИЙ КОМП'ЮТЕР]: {msg}");
                Console.ResetColor();
            };

            Console.WriteLine("=== Запуск системи SmartCar ===\n");

            myTravelCar.Drive();
            myTravelCar.VoiceCommand("статус");
            myTravelCar.TakeShower();

            // обробка винятків
            try
            {
                Console.WriteLine("\nСпроба доступу до неіснуючого пасажира...");
                var ghost = group[10];
            }
            catch (ArgumentOutOfRangeException ex)
            {
                Console.WriteLine($"Оброблено виняток: {ex.Message}");
            }

            Console.WriteLine("\nТест завершено. Натисніть будь-яку клавішу...");
            Console.ReadKey();
        }
    }
}