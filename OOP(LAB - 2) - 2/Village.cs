using System;
using System.Xml.Linq;

namespace OOP_LAB___4____1
{
    public class Selo : Mistevist, ICalc, IOutput
    {
        private int houses; // Специфічне поле

        public int Houses { get => houses; set => houses = value; }

        // Конструктор: назва має збігатися з назвою класу!
        public Selo(string name, int population, double area, int houses)
            : base(name, population, area)
        {
            this.houses = houses;
        }

        // Реалізація ICalc (п. 6)
        public double Calc() => GetDensity() * 1.2;

        // Реалізація IOutput (п. 7)
        public void Show()
        {
            Console.WriteLine($"[Interface Show] Село {Name}, потенціал розвитку: {Calc():F2}");
        }

        public override void Output()
        {
            base.Output();
            Console.WriteLine($"Кількість будинків: {houses}");
        }
    }
}