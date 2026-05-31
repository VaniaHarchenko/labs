using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// я додав ICalc щоб будь який об'єкт міг реалізувати свій алгоритм обчислення потенціалу 
namespace OOP_LAB___4____1
{
    public interface ICalc
    {
        double Calc(); // Метод для розрахунку потенціалу
    }

    public interface IOutput
    {
        void Show(); // Метод для виводу через інтерфейс
    }
}
