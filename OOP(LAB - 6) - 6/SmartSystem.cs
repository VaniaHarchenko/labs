using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP6
{
    // композиція: смарт-система
    public class SmartSystem
    {
        public double Temperature { get; set; } = 21.0;
        public bool IsDrunkDriverDetected { get; set; } = false;

        // температура та алкозамок
        public string GetStatus() => $"Темп: {Temperature}°C, Алкозамок: {(IsDrunkDriverDetected ? "ON" : "OFF")}";
    }
}
