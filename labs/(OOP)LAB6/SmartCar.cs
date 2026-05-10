using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _OOP_LAB6
{
    // агрегація та події 
    public class SmartCar
    {
        // протектед поля класу (інкапсуляція)
        protected readonly string Model; // назва моделі авто
        protected readonly Engine CarEngine; // тип двигуна (композиція)
        protected readonly Body CarBody; // кузов (композиція)
        protected readonly Chassis CarChassis; // шасі (композиція)
        protected readonly SmartSystem MySmartSystem; // смарт система
        protected readonly List<Person> Passengers; // список людей(агрегація) 

        public delegate void CarEventHandler(string message);
        public event CarEventHandler? OnSystemMessage;

        // конструктор (ініціалізація складових частин)
        public SmartCar(string model, List<Person> passengers)
        {
            // композиція (створено об'єкти) (при втраті - зникають)
            Model = model;
            CarEngine = new Engine();
            CarBody = new Body();
            CarChassis = new Chassis();
            MySmartSystem = new SmartSystem();
            Passengers = passengers ?? new List<Person>(); // агрегація (ліст пасажирів передається ззовні) (при втраті лишаються в пам'яті)
        }


        // сценарій безпеки ( перевірка водія)
        public virtual void Drive()
        {
            try
            {
                if (MySmartSystem.IsDrunkDriverDetected) throw new Exception("Алкозамок активовано!");
                if (Passengers.Count == 0) throw new Exception("У машині немає пасажирів!");

                CarEngine.Start();
                Notify($"Авто {Model} розпочало рух.");
                SaveToLog("Поїздка розпочата успішно.");
            }
            catch (Exception ex)
            {
                Notify($"Критичний збій: {ex.Message}");
                SaveToLog($"Помилка: {ex.Message}");
            }
        }
        
        // голосові команди
        public void VoiceCommand(string cmd)
        {
            if (cmd.Equals("статус", StringComparison.OrdinalIgnoreCase))
                Notify(MySmartSystem.GetStatus());
            else
                Notify($"Команда '{cmd}' прийнята до обробки.");
        }

        protected void Notify(string msg) => OnSystemMessage?.Invoke(msg);

        private static void SaveToLog(string text)
        {
            try { File.AppendAllText("car_log.txt", $"{DateTime.Now}: {text}\n"); }
            catch { }
        }
    }
}
