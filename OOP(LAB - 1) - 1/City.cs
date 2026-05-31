using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_LAB___4____1
{
    // місто походить від місцевість 
    class City : Mistevist
    {
        private int districts;

        // інкапсуляція
        public int Districts
        {
            get { return districts; }
            set { districts = value; }
        }

        // конструктор без параметрів для створення порожнього об'єкту
        public City() { }

        // через бейз передаємо дані батьківському класу
        public City(string name, int population, double area, int districts)
            : base(name, population, area)
        {
            this.districts = districts;
        }

        // базовий клас абстрактний
        public override void Input() { }

        public override void Output()
        {
            Console.WriteLine($"Місто: {Name}, Населення: {Population}, Площа: {Area}, Райони: {Districts}, Густота: {Density():F2}");
        }
    }
}