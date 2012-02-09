using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Cars.Phase6
{

    public class Lorry : Automobile //Inheritance
    {

        public Lorry(Engine engine, bool satnav, string manufacturer, string model, bool locked, string fueltype) : base(engine, satnav, manufacturer, model, locked, fueltype)
        {
            FuelCapacity = 150;
            AvgMPG = 10;
            Wheels = 6;
            Gears = 6;            
            TopSpeed = 120;
            Engine = engine;
        }

        public override string Reverse()
        {
            return("BEEP! BEEP! this vehical is reversing...\n");
        }

    }
}
