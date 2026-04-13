using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_LAB___4____1
{
   // шаблон для всіх наступних типів місцевості
    abstract class Mistevist
    {
        
        private string name;
        private int population;
        private double area;

        // властивості 
        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        public int Population
        {
            get { return population; }
            set { population = value; }
        }

        public double Area
        {
            get { return area; }
            set { area = value; }
        }

        // конструктор без параметрів
        public Mistevist() { }

        // конструктор з параметрами
        public Mistevist(string name, int population, double area)
        {
            this.name = name;
            this.population = population;
            this.area = area;
        }

        // абстрактні методи що реалізовані в похідних класах
        public abstract void Input();
        public abstract void Output();

        // розрахунок щільності населення 
        public double Density()
        {
            return population / area;
        }
    }
}