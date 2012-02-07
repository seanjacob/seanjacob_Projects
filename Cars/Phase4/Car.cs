using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Cars.Phase4
{

    public class Car : Automobile
    {


        public Car( bool satnav, string manufacturer, string model, bool locked, string fueltype) : base(satnav, manufacturer, model, locked, fueltype)
        {
            Wheels = 4;
            Gears = 5;
        }                

    }
}
