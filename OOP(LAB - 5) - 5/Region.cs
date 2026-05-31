using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_LAB5_
{
    // клас  регіон з індексатором для зберігання колекції областей
    class Region
    {
        private Area[] arr;

        public Region(int size)
        {
            arr = new Area[size];
        }

        // індексатор(доступ як до масиву)
        public Area this[int index]
        {
            get { return arr[index]; }
            set { arr[index] = value; }
        }

        // властивість для отримання довжини колекції
        public int Length
        {
            get { return arr.Length; }
        }
    }
}
