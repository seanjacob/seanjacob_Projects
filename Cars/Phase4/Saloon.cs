using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Cars.Phase4
{

    public class Saloon : Car
    {

        public string AlarmCode { get; set; }

        public Saloon(bool satnav, string manufacturer, string model, bool locked, string fueltype) : base(satnav,  manufacturer,  model, locked, fueltype)
        {
            
            FuelCapacity = 70;
            AvgMPG = 30;
            Wheels = 4;
            Gears = 5;
            EngineCC = 1800;
            TopSpeed = 150;
            AlarmCode = "abc12345";
        }

        public ReturnValue Unlock(string code)
        {
            if (code.Equals(AlarmCode))
            {
                Locked = false;
                return new ReturnValue(true, "Passcode allowed. Vehical unlocked.\n");
            }
            else
            {
                Locked = true;
                return new ReturnValue(false, "Passcode denied. Vehical locked.\n");                                
            }                                    
        }

        public override ReturnValue CheckFuelType(string type)
        {
            if (type.Equals(FuelType))
            {
                return new ReturnValue(true, "");
            }
            else
            {
                return new ReturnValue(false, "You're trying to add the wrong fuel type.\n");
            }
        }

    }
}
