using System;
using System.Xml.Linq;

namespace OOP_LAB___4____1
{
    public class Misto : Mistevist, ICalc, IOutput
    {
        private int districts; // Специфічне поле

        public int Districts { get => districts; set => districts = value; }

        public Misto(string name, int population, double area, int districts)
            : base(name, population, area)
        {
            this.districts = districts;
        }

        // Реалізація ICalc
        public double Calc() => GetDensity() * 5.5 + (districts * 100);

        // Реалізація IOutput
        public void Show()
        {
            Console.WriteLine($"[Interface Show] Місто {Name}, економічний потенціал: {Calc():F2}");
        }

        public override void Output()
        {
            base.Output();
            Console.WriteLine($"Кількість районів: {districts}");
        }
    }
}