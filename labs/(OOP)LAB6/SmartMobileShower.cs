using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _OOP_LAB6
{

    // Смарт душ
    public class SmartMobileShower : SmartCar
    {
        // прайват (інкапсуляція)
        private double _waterLevel = 40.0;

        public SmartMobileShower(string model, List<Person> passengers)
            : base(model, passengers) { }

        public void TakeShower()
        {
            if (_waterLevel >= 10)
            {
                _waterLevel -= 10;
                Notify($"Душ активовано. Залишилось води: {_waterLevel}л.");
            }
            else
            {
                Notify("Помилка: недостатньо води для душу!");
            }
        }

        public override void Drive()
        {
            Notify("Перевірка систем мобільного душу перед виїздом...");
            base.Drive();
        }
    }
}
