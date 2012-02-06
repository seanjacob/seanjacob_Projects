using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Cars.Phase4
{

    public class Hatchback : Car
    {

        public Hatchback(bool satnav, string manufacturer, string model) : base(  satnav,  manufacturer,  model)
        {
            
            FuelCapacity = 50;
            AvgMPG = 20;
            EngineCC = 1400;
            TopSpeed = 120;
        }                

    }
}
