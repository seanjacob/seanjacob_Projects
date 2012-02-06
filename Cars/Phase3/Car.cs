using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Cars.Phase3
{

    public class Car : Automobile
    {   

        public Car( bool satnav, string manufacturer, string model) : base(satnav, manufacturer, model)
        {
            
            FuelCapacity = 50;
            AvgMPG = 20;
            Wheels = 4;
            Gears = 5;
            EngineCC = 1400;
            TopSpeed = 120;
        }                

    }
}
