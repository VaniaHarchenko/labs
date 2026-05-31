using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_LAB5_
{
    class City : Area
    {
        public int Factories { get; set; }

        public City() { }

        public City(string name) : base(name) { }

        public City(string name, int population, double budget, int factories)
            : base(name, population, budget)
        {
            Factories = factories;
        }

        // конструктор копіювання
        public City(City other) : base(other)
        {
            Factories = other.Factories;
        }

        public override void Develop(int value)
        {
            Population += value * 2;
        }

        // перевантаження бінарного оператора +
        // об'єднання двох міст
        public static City operator +(City a, City b)
        {
            if (a is null || b is null)
                return new City();

            return new City(
                a.Name + "-" + b.Name,
                a.Population + b.Population,
                a.Budget + b.Budget,
                a.Factories + b.Factories
            );
        }

        // перевантаження унарного оператора --
        // зменшує населення
        public static City operator --(City a)
        {
            if (a is null) return new City();

            a.Population -= 100;
            return a;
        }
    }
}