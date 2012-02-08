using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Cars.Phase5
{

    public class Lorry : Automobile
    {

        public Lorry(bool satnav, string manufacturer, string model, bool locked, string fueltype) : base(satnav, manufacturer, model, locked, fueltype)
        {
            FuelCapacity = 150;
            AvgMPG = 10;
            Wheels = 6;
            Gears = 6;
            EngineCC = 2000;
            TopSpeed = 120;
        }

        public override string Reverse()
        {
            return("BEEP! BEEP! this vehical is reversing...\n");
        }

    }
}
