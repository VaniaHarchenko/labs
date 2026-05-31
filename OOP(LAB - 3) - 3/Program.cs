using System;
using System.Collections.Generic;
using System.Text;

namespace OOP_LAB_4_1
{
    class Program
    {
        static void Main()
        {
            Console.OutputEncoding = Encoding.UTF8;

            // Створюємо список абстрактного типу
            List<Mistevist> list = new List<Mistevist>();

            list.Add(new Village("Веселе", 450, 20.0, 150.5));
            list.Add(new City("Харків", 1400000, 350.0, 42));

            Console.WriteLine("=== ТЕСТ АБСТРАКТНОЇ ІЄРАРХІЇ ===\n");

            foreach (var item in list)
            {
                item.Output(); // Викличеться правильна реалізація для кожного типу
                Console.WriteLine($"Спільний метод (Густота): {item.GetDensity():F2}");
                Console.WriteLine("-----------------------------------");
            }
        }
    }
}