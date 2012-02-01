using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Cars.Phase2
{
    public class Car
    {

        public decimal FuelLevel { get; set; }
        public decimal FuelCapacity { get; set; }
        public decimal Mileage { get; set; }
        public decimal AvgMPG { get; set; }
        public int Wheels { get; set; }
        public int Gears { get; set; }
        public int EngineCC { get; set; }
        public int TopSpeed { get; set; }
        public string Manufacturer { get; set; }
        public string Model { get; set; }
        public string Info { get; set; }
        public decimal DriveAmount { get; set; }

        public Car() 
        {
            FuelCapacity = 50;
            AvgMPG = 10;
            Manufacturer = "Citroen";
            Model = "Saxo";
            Wheels = 4;
            Gears = 5;
            EngineCC = 1400;
            TopSpeed = 120;
        }
        
        void CalculateInfo()
        {
            string[] infoArr = { 
                                   "Wheels", Wheels.ToString(), 
                                   "Top Speed", TopSpeed.ToString(),
                                   "Gears", Gears.ToString(),
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

        public string Drive()
        {
            Mileage += DriveAmount;
            Info = "You have drove " + DriveAmount + " miles. Total car mileage " + Mileage + "\n";
            return(Info);
        }

        public ReturnValue Plan(decimal miles)
        {
            decimal fuelNeeded = miles / AvgMPG;

            if (FuelLevel >= fuelNeeded)
            {                
                DriveAmount = miles;
                FuelLevel -= fuelNeeded;                
                return new ReturnValue(true, "After " + miles + " miles you will have " + FuelLevel + " litres remaining. Would you like to take this journey Y/N?" );
            }
            else
            {
                return new ReturnValue(false, "You dont have enough fuel for this journey. \n");
            }
        }

    }
}
