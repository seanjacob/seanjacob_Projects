using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Cars.Phase5
{

    public class Hatchback : Car //Inheritance
    {

        public Hatchback(Engine engine, bool satnav, string manufacturer, string model, bool locked, string fueltype) : base(engine, satnav, manufacturer, model, locked, fueltype)
        {
            
            FuelCapacity = 50;
            AvgMPG = 20;            
            TopSpeed = 120;
            Engine = engine;
        }                

    }
}
