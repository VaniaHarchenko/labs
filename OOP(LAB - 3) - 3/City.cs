using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace OOP_LAB_4_1
{
    public class City : Mistevist
    {
        private int factories; // Специфічне поле: кількість заводів

        public City(string name, int population, double area, int factories)
            : base(name, population, area)
        {
            this.factories = factories;
        }

        public override void Output()
        {
            Console.WriteLine($"[Міська місцевість] {Name}");
            Console.WriteLine($"- Населення: {Population}, Площа: {Area}, Заводів: {factories}");
            Console.WriteLine($"- Екон. потенціал: {CalculatePotential():F2}");
        }

        public override double CalculatePotential()
        {
            // Потенціал залежить від промисловості та густоти населення
            return (factories * 500) + GetDensity();
        }
    }
}
