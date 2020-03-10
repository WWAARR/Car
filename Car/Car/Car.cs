using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace Car
{
    class Car
    {
        Engine engine;
        Tank tank;
        uint speed;
        uint max_speed;
        public Engine Engine{get =>engine;private set => engine = value;}
        public Tank Tank { get => tank; private set => tank = value;}
        public uint Speed { get => speed; set => speed = value < max_speed ? value : max_speed; }
        public uint MaxSpeed { get => max_speed;private set => max_speed = value <=420 ? value :
                throw new Exception("Error:You criminal scum.You violated the low!"); }
        public bool DriverInside { get; set; }
        public Control Control { get; set; }
        public Car(Engine engine, Tank tank)
        {
            Engine = engine;
            Tank = tank;
            if (Engine.Power >= 50 && Engine.Power <= 200)
            {
                MaxSpeed = Convert.ToUInt32((double)Engine.Power * 1.4);
            }
            else if (Engine.Power >= 200 && Engine.Power <= 300)
            {
                MaxSpeed = Engine.Power * 120 / 100;
            }
            else if (Engine.Power >= 300 && Engine.Power <= 500)
            {
                MaxSpeed = Engine.Power * 80 / 100;
            }
            else
            {
                MaxSpeed = Engine.Power * 40 / 100;
            }
            Control = new Control();
        }
        public void Fill(double amount)
        {
            tank.Fill(amount);
        }
        public void Panel()
        {
            Console.Clear();
            Console.WriteLine($"Engine is{(engine.Started?"started":"stopped")}");
            Console.WriteLine($"Fuel level : {(tank.Fuel)}");
            if (tank.Fuel < 5)
            {
                ConsoleColor defaultColor = Console.ForegroundColor;
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Low fuel");
                Console.ForegroundColor = defaultColor;

            }
            Thread.Sleep(1000);
        }
        public void GetIn()
        {
            DriverInside = true;
            Control.tControlPanelThread = new Thread(Panel);
            Control.tControlPanelThread.Start();
        }
        public void GetOut()
        {
            DriverInside = false;
            Control.tControlPanelThread.Join();
        }
        public bool Start()
        {
            if (tank.Fuel > 0)
            {
                engine.Started = true;
                Control.tControlPanelThread = new Thread(EngineIdle);
                Control.tControlPanelThread.Start();
            }
            else
            {
                Console.WriteLine("No fuel");
            }
            return engine.Started;                 
        }
        public void Stop()
        {
            engine.Started = false;
            if(Control.tEngineIdleThread != null)Control.tControlPanelThread.Join();
        }
        public void EngineIdle()
        {
            while (engine.Started && tank.Fuel>0)
            {
                tank.Fuel -= engine.ConsumptionPerSecond;
                Thread.Sleep(1000);
            }
        }
        public override string ToString()
        {
            return $"{Engine.ToString()}\n{Tank.ToString()} MaxSpeed:\t{MaxSpeed}km/h";
        }
    }
}
