using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Car
{
    class Program
    {
        static void Main(string[] args)
        {
            //Tank tank = new Tank(40);
            //tank.Fill(20);
            //tank.Fill(10);
            //Console.WriteLine(tank);

            //Engine engine = new Engine(200);

            //Console.WriteLine(engine);

            Car car = new Car(new Engine(250), new Tank(40));
            Console.WriteLine(car);

            Console.WriteLine("Your car is ready,press enter go get into");
            Console.ReadKey();
            car.GetIn();

            ConsoleKey key;
            do
            {
                key = Console.ReadKey(true).Key;

                switch (key)
                {
                    case ConsoleKey.Enter:
                        if (!car.Engine.Started) car.Start();
                        else car.Stop();
                       break;
                    case ConsoleKey.F:
                        car.Control.tControlPanelThread.Suspend();
                        Console.WriteLine("How much?");
                        car.Fill(Convert.ToDouble(Console.ReadLine()));
                        car.Control.tControlPanelThread.Resume();
                        break;
                    case ConsoleKey.Escape:
                        car.Stop();
                        car.GetOut();
                        break;
                }
            } while (key != ConsoleKey.Escape);

        }
    }
}
