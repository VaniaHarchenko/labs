using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP6
{
    // композиція: двигун
    public class Engine
    {
        public bool IsRunning { get; private set; }
        public void Start()
        {
            IsRunning = true;
        }
    }
}
