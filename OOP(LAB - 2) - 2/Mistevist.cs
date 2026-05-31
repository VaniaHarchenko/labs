using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_LAB___4____1
{
    public class Mistevist
    {
        private string name;
        private int population;
        private double area;

        // Конструктор базового класу (п. 2)
        public Mistevist(string name, int population, double area)
        {
            this.name = name;
            this.population = population;
            this.area = area;
        }

        // Властивості (п. 4)
        public string Name { get => name; set => name = value; }
        public int Population { get => population; set => population = value; }
        public double Area { get => area; set => area = value; }

        // Розрахунок густоти для внутрішнього використання
        protected double GetDensity() => area > 0 ? population / area : 0;

        public virtual void Output()
        {
            Console.WriteLine($"Місцевість: {name}, Населення: {population}, Площа: {area}");
        }
    }
}
