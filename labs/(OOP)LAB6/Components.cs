using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _OOP_LAB6
{
    public class Person
    {
        public string Name { get; set; }
        public Person(string name) => Name = name;
    }

    // композиція: двигун
    public class Engine
    {
        public bool IsRunning { get; private set; }
        public void Start() => IsRunning = true;
    }

    // композиція: кузов та шасі
    public class Body { public string Color = "White"; }
    public class Chassis { public string Status = "Normal"; }

    // композиція: смарт-система
    public class SmartSystem
    {
        public double Temperature { get; set; } = 21.0;
        public bool IsDrunkDriverDetected { get; set; } = false;

        // тепература та алкозамок
        public string GetStatus() => $"Темп: {Temperature}°C, Алкозамок: {(IsDrunkDriverDetected ? "ON" : "OFF")}";
    }
}
