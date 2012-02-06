using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Cars.Phase4
{

    public class Car : Automobile
    {


        public Car( bool satnav, string manufacturer, string model, bool locked) : base(satnav, manufacturer, model, locked)
        {
            Wheels = 4;
            Gears = 5;
        }                

    }
}
