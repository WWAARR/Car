using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Car
{
    class Tank
    {
        uint volume;//characteristics
        double fuel;//object condition
        public uint Volume
        {
            get => volume;
            private set => volume = value >= 40 && value <= 120 ? value : throw new Exception("Bad tank volume");
        }
        public double Fuel
        {
            get => fuel;
            set
            {
                fuel = value;
                if (fuel < 0) fuel = 0;
                if (fuel > volume) fuel = volume;
            }
        }
        public Tank(uint volume)
        {
            Volume = volume;
            Fuel = 0;
        }

        public void Fill(double fuel)
        {
            Fuel += fuel;
        }

        public override string ToString()
        {
            return $"Tank volume : {Volume};\nFuel level : {Fuel};";
        }
    }
}