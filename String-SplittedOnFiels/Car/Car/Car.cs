using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

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
        }
    }
}
