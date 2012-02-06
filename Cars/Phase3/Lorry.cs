using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Cars.Phase3
{

    public class Lorry : Automobile
    {

        public Lorry(bool satnav, string manufacturer, string model) : base(satnav, manufacturer, model)
        {
            FuelCapacity = 150;
            AvgMPG = 10;
            Wheels = 6;
            Gears = 6;
            EngineCC = 2000;
            TopSpeed = 120;
        }

        public override string GetInfo(string g)
        {
            return "Lorry";
        }

    }
}
