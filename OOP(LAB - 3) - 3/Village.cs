using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace OOP_LAB_4_1
{
    public class Village : Mistevist
    {
        private double arableLand; // Специфічне поле: площа орних земель

        public Village(string name, int population, double area, double arableLand)
            : base(name, population, area)
        {
            this.arableLand = arableLand;
        }

        // Реалізація виводу (п. 5)
        public override void Output()
        {
            Console.WriteLine($"[Сільська місцевість] {Name}");
            Console.WriteLine($"- Населення: {Population}, Площа: {Area}, Ріллля: {arableLand} га");
            Console.WriteLine($"- Екон. потенціал: {CalculatePotential():F2}");
        }

        // Реалізація розрахунку (п. 6)
        public override double CalculatePotential()
        {
            // Потенціал залежить від кількості землі на одного жителя
            return (arableLand * 100) / (Population > 0 ? Population : 1);
        }
    }
}
