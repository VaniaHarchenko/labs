using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_LAB5_
{
    class Village : Area
    {
        public int Farms { get; set; }

        public Village() { }

        public Village(string name) : base(name) { }

        public Village(string name, int population, double budget, int farms)
            : base(name, population, budget)
        {
            Farms = farms;
        }

        // конструктор копіювання
        public Village(Village other) : base(other)
        {
            Farms = other.Farms;
        }

        public override void Develop(int value)
        {
            Farms += value;
            Population += value;
        }

        // оператор > 
        public static bool operator >(Village a, Village b)
        {
            if (a is null || b is null) return false;
            return a.Population > b.Population;
        }

        // оператор < 
        public static bool operator <(Village a, Village b)
        {
            if (a is null || b is null) return false;
            return a.Population < b.Population;
        }

        // унарний оператор ++
        public static Village operator ++(Village a)
        {
            if (a is null) return new Village();

            a.Farms++;
            return a;
        }
    }
}