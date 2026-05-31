using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_LAB___4____1
{
    public class City : Miscevist, IComparable<City>
    {
        private string name;
        private decimal budget;

        public string Name { get => name; set => name = value; }
        public decimal Budget { get => budget; set => budget = value; }

        public City(string name, double size, int pop, decimal budget) 
            : base(size, pop)
        {
            this.name = name;
            this.budget = budget;
        }

        public override void ShowInfo()
        {
            Console.WriteLine($"Місто: {Name,-10} | Площа: {TerritorySize,6} км² | " +
                              $"Населення: {Population,8} | Бюджет: {Budget,10:C}");
        }

        // Реалізація IComparable для порівняння за розміром території
        public int CompareTo(City other)
        {
            if (other == null) return 1;
            return this.TerritorySize.CompareTo(other.TerritorySize);
        }
    }
}
