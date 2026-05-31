using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
namespace OOP_LAB_4_1
{
    // Абстрактний клас - основа ієрархії (п. 8)
    public abstract class Mistevist
    {
        // Приватні поля (п. 1)
        private string name;
        private int population;
        private double area;

        // Конструктор з параметрами (п. 2)
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

        // Абстрактні методи (п. 5, 6) - обов'язкові для реалізації в Selo та Misto
        public abstract void Output();
        public abstract double CalculatePotential();

        // Звичайний метод, який успадкують всі (перевага абстрактного класу над інтерфейсом)
        public double GetDensity() => area > 0 ? population / area : 0;
    }
}
