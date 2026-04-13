
// 1 застосунок
// створив базовий абстрактний клас місцевість 
// реалізував похілні класи село та місто з специфічними полями
// використав конструктори з параметрами та слово base для ієрархії
// доступ до закритих полів через властивості
// у методі мейн створив список для щоб зберегти місто та село в одній колекції List<Mistevist>, 
// релізував оверайд щоб програма могла застосовувати логіку для кожного об'єкту (ГПТ)

using OOP_LAB___4____1;
using System;
using System.Collections.Generic;
using System.Text;
class Program
{
    static void Main()
    {
        // кодування консолі
        Console.OutputEncoding = Encoding.UTF8;
        Console.InputEncoding = Encoding.UTF8;

        // список базового типу місцевість щоб зберегти об'єкти Село та Місто в одній колекції
        List<Mistevist> list = new List<Mistevist>();

        // заповнюємо список 
        list.Add(new Village { Name = "Ковалівка", Population = 1000, Area = 50, Houses = 200 });
        list.Add(new City { Name = "Чорнобиль", Population = 50000, Area = 300, Districts = 5 });

        foreach (var item in list)
        {
            item.Output();
        }
    }
}