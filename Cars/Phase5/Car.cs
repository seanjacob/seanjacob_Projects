using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Cars.Phase5
{

    public class Car : Automobile //Inheritance
    {


        public Car(Engine engine, bool satnav, string manufacturer, string model, bool locked, string fueltype) : base(engine, satnav, manufacturer, model, locked, fueltype)
        {
            Wheels = 4;
            Gears = 5;
            Engine = engine;
        }                

    }
}
