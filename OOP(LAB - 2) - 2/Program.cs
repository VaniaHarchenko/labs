using System;
using System.Collections.Generic;
using System.Text;

namespace OOP_LAB___4____1
{
        class Program
        {
            static void Main(string[] args)
            {
                // Встановлюємо кодування для коректного відображення кирилиці
                Console.OutputEncoding = Encoding.UTF8;

                // Створюємо список, що містить об'єкти базового класу (Поліморфізм)
                List<Mistevist> locations = new List<Mistevist>();

                // Додаємо об'єкти (використовуємо правильні назви класів Selo та Misto)
                locations.Add(new Selo("Ковалівка", 1200, 15.5, 300));
                locations.Add(new Misto("Київ", 3500000, 835.5, 10));

                Console.WriteLine("--- 1. Виклик стандартних методів класу (п. 5) ---");
                foreach (var loc in locations)
                {
                    loc.Output();
                    Console.WriteLine("-------------------------------------------");
                }

                Console.WriteLine("\n--- 2. Доступ до методів через інтерфейс (п. 7) ---");
                foreach (var loc in locations)
                {
                    // Перевіряємо, чи реалізує об'єкт інтерфейс IOutput
                    if (loc is IOutput interfaceReference)
                    {
                        // Викликаємо метод через посилання на інтерфейс
                        interfaceReference.Show();
                    }

                    // Також можемо перевірити інтерфейс розрахунку потенціалу
                    if (loc is ICalc calcReference)
                    {
                        Console.WriteLine($"Економічний показник: {calcReference.Calc():F2}");
                    }
                    Console.WriteLine();
                }

                Console.ReadKey();
            }
        }
}