using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_LAB5_
{
    // селище міського типу що поєднує риси міста та села 
    class UrbanVillage : Area
    {
        public int Resorts { get; set; }

        public UrbanVillage() { }

        public UrbanVillage(string name) : base(name) { }

        public UrbanVillage(string name, int population, double budget, int resorts)
            : base(name, population, budget)
        {
            Resorts = resorts;
        }

        // конструктор копіювання
        public UrbanVillage(UrbanVillage other) : base(other)
        {
            Resorts = other.Resorts;
        }

        public override void Develop(int value)
        {
            Resorts += value;
            Population += value;
        }

        // оператор ==
        public static bool operator ==(UrbanVillage a, UrbanVillage b)
        {
            if (ReferenceEquals(a, b)) return true;
            if (a is null || b is null) return false;

            return a.Population == b.Population;
        }

        // оператор != (нерівності) 
        public static bool operator !=(UrbanVillage a, UrbanVillage b)
        {
            return !(a == b);
        }

        public override bool Equals(object? obj)
        {
            if (obj is UrbanVillage other)
                return this.Population == other.Population;

            return false;
        }

        public override int GetHashCode()
        {
            return Population.GetHashCode();
        }
    }
}
