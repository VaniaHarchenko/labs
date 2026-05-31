using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_LAB5_
{
    class Area
    {
        public string Name { get; set; } = "";
        public int Population { get; set; }
        public double Budget { get; set; }

        public Area() { }

        public Area(string name)
        {
            Name = name;
        }

        public Area(string name, int population, double budget)
        {
            Name = name;
            Population = population;
            Budget = budget;
        }

        // конструктор копіювання
        public Area(Area other)
        {
            Name = other.Name;
            Population = other.Population;
            Budget = other.Budget;
        }

        // віртуальний метод розвитку (може перевизначатися в нащадках)
        public virtual void Develop(int value)
        {
            Population += value;
        }

        // перевантаження методу (overload) (створення кількох версій методу з різними параметрами)
        public void Develop()
        {
            Develop(10);
        }

        // перевантаження методу (overload) (створення кількох версій методу з різними параметрами)
        public override string ToString()
        {
            return $"{Name} | Population: {Population} | Budget: {Budget}";
        }
    }
}