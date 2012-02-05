using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Cars.Phase3
{
 
    public class Automobile
    {
        public decimal FuelLevel { get; set; }
        public decimal FuelCapacity { get; set; }
        public decimal Mileage { get; set; }
        public decimal AvgMPG { get; set; }        
                
        public string Info { get; set; }
        public bool MOT { get; set; }
        public bool SatNav { get; set; }        


        public Automobile( bool satnav ) 
        {
            MOT = true;
            SatNav = satnav;            
        }
        
        void CalculateInfo()
        {
            string[] infoArr = { 
                                   "MOT", MOT.ToString(),
                                   "Sat Nav", SatNav.ToString(),
                                   "Manufacturer", Car.Manufacturer,
                                   "Model", Car.Model,
                                   "Wheels", Car.Wheels.ToString(),
                                   "Gears", Car.Gears.ToString(),                                                                      
                                   "Fuel Level", FuelLevel.ToString()
                               };

            for(int i = 0; i < infoArr.Length; i++)            
            {                 
                Info = Info + infoArr[i] + ": ";
                i++;
                Info = Info + infoArr[i] + "\n";
            }
        }

        public string GetInfo()
        {
            Info = "";
            CalculateInfo();
            return (Info);
        }


        public ReturnValue AddFuel(decimal amount)
        {
            decimal newLevel = FuelLevel + amount;

            if (newLevel <= FuelCapacity)
            {
                FuelLevel = newLevel;
                return new ReturnValue(true, "Fuel added. Current capacity is " + FuelLevel + " litres. \n");
            }
            else
            {
                decimal available = FuelCapacity - FuelLevel;
                return new ReturnValue(false, "That’s too much you can only add " + available + " litres.  Do you want to try again Y/N?");
            }
        }

        public string Drive(decimal mileageAmount)
        {
            Mileage += mileageAmount;
            FuelLevel -= (mileageAmount / AvgMPG);
            Info = "You have driven " + mileageAmount + " miles. Total car mileage " + Mileage + "\n";
            return(Info);
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
