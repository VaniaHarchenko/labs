using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP_LAB___4____1
{
    public class CityAreaPopulationComp : IComparer<City>
    {
        public int Compare(City x, City y)
        {
            if (x == null || y == null) return 0;

            // Сортування за територією
            int result = x.TerritorySize.CompareTo(y.TerritorySize);

            // Якщо площа однакова, сортуємо за населенням
            if (result == 0)
                result = x.Population.CompareTo(y.Population);

            return result;
        }
    }
}
