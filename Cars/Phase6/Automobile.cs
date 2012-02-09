using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Cars.Phase6
{

    
    public class Automobile
    {
        public decimal FuelLevel { get; set; }
        public decimal FuelCapacity { get; set; }
        
        public decimal AvgMPG { get; set; }
        public int Wheels { get; set; }
        public int Gears { get; set; }        
        public int TopSpeed { get; set; }
        public string Manufacturer { get; set; }
        public string Model { get; set; }
        public string FuelType { get; set; }
                
        public string Info { get; set; }
        public bool MOT { get; set; }
        public bool SatNav { get; set; }
        public bool Locked { get; set; }

        public Engine Engine { get; set; } //Association
    

        public Automobile(Engine engine, bool satnav, string manufacturer, string model, bool locked, string fueltype) 
        {
            MOT = true;
            SatNav = satnav;
            Manufacturer = manufacturer;
            Model = model;
            Locked = locked;
            FuelType = fueltype;
            Engine = engine;
        }
        
        private void CalculateInfo()
        {
            string[] infoArr = { 
                                    "MOT", MOT.ToString(),
                                    "Sat Nav", SatNav.ToString(),
                                    "Locked", Locked.ToString(),
                                    "Manufacturer", Manufacturer,
                                    "Model", Model,
                                    "Wheels", Wheels.ToString(),
                                    "Gears", Gears.ToString(),                                                                      
                                    "Fuel Level", FuelLevel.ToString(),
                                    "Fuel Type", FuelType.ToString(),
                                    "EngineCC", Engine.EngineCC.ToString(),
                                    "Mileage", Engine.Mileage.ToString(),
                                    "Service Needed", Engine.ServiceNeeded.ToString()
                                };

            for(int i = 0; i < infoArr.Length; i++)            
            {                 
                Info = Info + infoArr[i] + ": ";
                i++;
                Info = Info + infoArr[i] + "\n";
            }
        }

      
        public virtual string GetInfo()
        {
                Info = "";
                CalculateInfo();
                return Info;
        }

        public ReturnValue Lock()
        {
            Locked = true;
            return new ReturnValue(true, "Vehical locked.\n");
        }

        public virtual ReturnValue Unlock()
        {
            Locked = false;
            return new ReturnValue(true, "Vehical unlocked.\n");
        }

        public virtual string Reverse()
        {
            return("This vehical is reversing...\n");
        }

        public string AddFuel(decimal amount)
        {            
            FuelLevel += amount;
            return ("Fuel added. Current capacity is " + FuelLevel + " litres.\n");                
        }

        public ReturnValue CheckFuelAmount(decimal amount)
        {
            decimal newLevel = FuelLevel + amount;
            if (newLevel <= FuelCapacity)
            {                
                return new ReturnValue(true, "");
            }
            else
            {
                decimal available = FuelCapacity - FuelLevel;
                return new ReturnValue(false, "That’s too much you can only add " + available + " litres.\n");
            }
        }

        public virtual ReturnValue CheckFuelType(string fueltype)
        {
            return new ReturnValue(true, "");
        }

        public void Drive(decimal mileageAmount)
        {            
            FuelLevel -= (mileageAmount / AvgMPG);

            Console.WriteLine(Engine.AddMileage(mileageAmount));
        }

        public ReturnValue Plan(decimal miles)
        {
            decimal FuelNeeded = miles / AvgMPG;

            if (FuelLevel >= FuelNeeded)
            {                                
                decimal fuelLeft = FuelLevel - FuelNeeded;
                
                return new ReturnValue(true, "After " + miles + " miles you will have " + fuelLeft + " litres remaining. Would you like to take this journey Y/N?" );
            }
            else
            {
                return new ReturnValue(false, "You don't have enough fuel for this journey. \n");
            }
        }

    }
}
