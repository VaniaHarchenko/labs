using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_LAB___4____1
{
    // Клас-контейнер, що реалізує IEnumerable
    public class CityList : IEnumerable
    {
        private City[] _cities;

        public CityList(City[] cityArray)
        {
            // Створюємо копію та сортуємо її за населенням, як просить завдання
            _cities = (City[])cityArray.Clone();
            Array.Sort(_cities, (a, b) => a.Population.CompareTo(b.Population));
        }

        // Реалізація інтерфейсу IEnumerable
        public IEnumerator GetEnumerator()
        {
            return new CityEnumerator(_cities);
        }

        // Вкладений клас, що реалізує IEnumerator (вимога завдання 9)
        private class CityEnumerator : IEnumerator
        {
            private City[] _cities;
            private int _position = -1;

            public CityEnumerator(City[] list)
            {
                _cities = list;
            }

            public bool MoveNext()
            {
                _position++;
                return (_position < _cities.Length);
            }

            public void Reset()
            {
                _position = -1;
            }

            public object Current
            {
                get
                {
                    try
                    {
                        return _cities[_position];
                    }
                    catch (IndexOutOfRangeException)
                    {
                        throw new InvalidOperationException();
                    }
                }
            }
        }
    }
}
