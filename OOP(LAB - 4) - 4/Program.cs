// 4 застосунок
// IComparable<City> реалізував в класі City для сортування за замовчуванням (за територією)
// IComparer<City>: Створив окремий клас CityAreaPopulationComp для складного сортування(спочатку за територією, потім за населенням).
// IEnumerable та IEnumerator Реалізував в класі CityList для створення колекції міст для перебору
using System;
using System.Collections.Generic;
using System.Text;
namespace OOP_LAB___4____1

{
    class Program
    {
        static void Main(string[] args)
        {
            // Встановлюємо кодування для коректного відображення гривні та кирилиці
            Console.OutputEncoding = Encoding.UTF8;

            // Створюємо масив об'єктів класу Місто
            City[] citiesArray = new City[]
            {
                new City("Київ", 839.0, 2800000, 60000000000m),
                new City("Львів", 182.0, 720000, 12000000000m),
                new City("Одеса", 162.4, 1010000, 11000000000m)
            };

            Console.WriteLine("=== Сортування за територією (IComparable) ===");
            Array.Sort(citiesArray);
            foreach (var city in citiesArray) city.ShowInfo();

            Console.WriteLine("\n=== Сортування за територією та населенням (IComparer) ===");
            Array.Sort(citiesArray, new CityAreaPopulationComp());
            foreach (var city in citiesArray) city.ShowInfo();

            Console.WriteLine("\n=== Список за населенням (IEnumerable/IEnumerator) ===");
            // Використовуємо наш спеціальний клас
            CityList cityCollection = new CityList(citiesArray);
            foreach (City city in cityCollection)
            {
                city.ShowInfo();
            }

            Console.WriteLine("\nРоботу завершено. Натисніть Enter.");
            Console.ReadLine();
        }
    }
}