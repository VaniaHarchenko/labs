using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_LAB___4____1
{
    public abstract class Miscevist
    {
        private double territorySize;
        private int population;

        public double TerritorySize
        {
            get => territorySize;
            set => territorySize = value;
        }

        public int Population
        {
            get => population;
            set => population = value;
        }

        protected Miscevist(double size, int pop)
        {
            territorySize = size;
            population = pop;
        }

        public abstract void ShowInfo();
    }
}
