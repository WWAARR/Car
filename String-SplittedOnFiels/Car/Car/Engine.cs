using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Car
{
    class Engine
    {
        uint power;
        bool started;
        double consumption;
        public uint Power
        {
            get => power;
            set
            {
                if (value >= 50 && value <= 1000)
                {
                    power = value >=50 && value <= 1000 ?value : throw new Exception("Error:bad engine power"); 
                }
            }
        }
        public double Consumption
        {
            get => consumption;
            private set => consumption = value;
            //{
            //    consumption = .0002 * (Power / 15);
            //}
        }
        public bool Started{ get; set; }
        public Engine(uint power)
        {
            Power = power;
            consumption = .0002 * (Power / 15);
            Started = false;
        }
        public override string ToString()
        {
            return $"Power:{Power} h/p, Consumption ({Consumption*3600}), engine {(Started?"starter" : "stopped")}";
        }
    }
}
