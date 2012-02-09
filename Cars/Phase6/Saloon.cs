using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Cars.Phase6
{

    public class Saloon : Car //Inheritance
    {

        public string AlarmCode { get; set; }

        public Saloon(Engine engine, bool satnav, string manufacturer, string model, bool locked, string fueltype) : base(engine, satnav, manufacturer, model, locked, fueltype)
        {
            
            FuelCapacity = 70;
            AvgMPG = 30;
            Wheels = 4;
            Gears = 5;                        
            AlarmCode = "abc12345";
            Engine = engine;
        }

        public override ReturnValue Unlock()
        {
            return Unlock("");
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
