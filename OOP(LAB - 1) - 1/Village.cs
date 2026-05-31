using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_LAB___4____1
{
    // клас що описує село спадкування від місцевості
    class Village : Mistevist
    {
        // закрите специфічне поле
        private int houses;

        public int Houses
        {
            get { return houses; }
            set { houses = value; }
        }

        // конструктор без параметрів
        public Village() { }

        // конструсктор з параметрами (бейз передає дані до батьківського класу Місцевість)
        public Village(string name, int population, double area, int houses)
            : base(name, population, area)
        {
            this.houses = houses;
        }

        // поліморфізм (викликання методу через посилання на базовий клас) 
        public override void Input() { }

        public override void Output()
        {
            Console.WriteLine($"Село: {Name}, Населення: {Population}, Площа: {Area}, Будинки: {Houses}, Густота: {Density():F2}");
        }
    }
}