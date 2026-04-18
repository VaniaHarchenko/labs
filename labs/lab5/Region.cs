using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_LAB5_
{
    class Region
    {
        private Area[] arr;

        public Region(int size)
        {
            arr = new Area[size];
        }

        public Area this[int index]
        {
            get { return arr[index]; }
            set { arr[index] = value; }
        }

        public int Length
        {
            get { return arr.Length; }
        }
    }
}
