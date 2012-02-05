using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Cars.Phase3;

namespace Cars
{
    public class Program
    {
                
        public static void Main(string[] args)
        {
            //RunProgram1();
            //Program2 myObject = new Program2();
            
            Program3 myObject = new Program3();

            Console.WriteLine("Welcome to my car app. Please see the available commands below:");
            Console.WriteLine("1. get info - get info of car");
            Console.WriteLine("2. add fuel - add fuel to car");
            Console.WriteLine("3. plan - plan journey \n");
            
            while (true) // Loop indefinitely
            {                
                string userCommand = Console.ReadLine().ToLower(); // Get string from user                
                myObject.Run(userCommand);
            }
            
        }



        public static decimal FuelLevel { get; set; }
        public static decimal FuelCapacity { get; set; }
        public static decimal Mileage { get; set; }
        public static decimal AvgMPG { get; set; }
        public static int Wheels { get; set; }
        public static int Gears { get; set; }
        public static int EngineCC { get; set; }
        public static int TopSpeed { get; set; }
        public static string manufacturer { get; set; }
        public static string model { get; set; }

        public static void RunProgram1()
        {
            FuelLevel = 0;
            FuelCapacity = 50;
            Mileage = 0;
            AvgMPG = 10;
            Wheels = 4;
            Gears = 5;
            EngineCC = 1400;
            TopSpeed = 120;
            manufacturer = "Citroen";
            model = "Saxo";


            Console.WriteLine("Welcome to my car app. Please see the available commands below:");
            Console.WriteLine("1. get info - get info of car");
            Console.WriteLine("2. add fuel - add fuel to car");
            Console.WriteLine("3. drive - add mileage to car");
            while (true) // Loop indefinitely
            {
                string userCommand = Console.ReadLine().ToLower(); // Get string from user
                if (userCommand.StartsWith("add fuel")) // Check string
                {
                    try
                    {
                        decimal fuelAmount = decimal.Parse(userCommand.Replace("add fuel", "").Trim());
                        AddFuel(fuelAmount);
                    }
                    catch (Exception)
                    {
                        Console.Write("Sorry an error occured trying to add the fuel");
                    }

                }
                else if (userCommand.StartsWith("drive"))
                {
                    try
                    {
                        decimal mileageAmount = decimal.Parse(userCommand.Replace("drive", "").Trim());
                        Drive(mileageAmount);
                    }
                    catch (Exception)
                    {
                        Console.Write("Sorry an error occured trying to add mileage");
                    }
                }
                else if (userCommand.StartsWith("get info"))
                {
                    GetInfo();
                }
                else
                {
                    Console.Write("Sorry I didnt catch that? ");
                }
            }

        }

        public static void AddFuel(decimal amount)
        {
            decimal newLevel = FuelLevel + amount;
            if (newLevel > FuelCapacity)
            {
                decimal available = FuelCapacity - FuelLevel;
                Console.Write("Sorry you tried to add too much fuel, the cars capactity is {0} you only have {1} litres remaining", FuelCapacity, available);
            }
            else
            {
                FuelLevel = newLevel;
                Console.WriteLine("Fuel added new level at " + FuelLevel);
            }
        }

        public static void GetInfo()
        {
            Console.WriteLine("Manufacturer: " + manufacturer);
            Console.WriteLine("Model: " + model);
            Console.WriteLine("Engine CC: " + EngineCC);
            Console.WriteLine("Top Speed: " + TopSpeed);
            Console.WriteLine("Wheels: " + Wheels);            
            Console.WriteLine("Gears: " + Gears);
            Console.WriteLine("Mileage: " + Mileage);
            Console.WriteLine("Fuel Capacity: " + FuelCapacity);
            Console.WriteLine("Average MPG: " + AvgMPG);
            Console.WriteLine("Current Fuel Level: " + FuelLevel);
        }

        public static void Drive(decimal miles)
        {                        
            decimal fuelNeeded = miles / AvgMPG;

            if (FuelLevel >= fuelNeeded)
            {
                Mileage += miles;
                FuelLevel -= fuelNeeded;
                Console.WriteLine("Your fuel level is now " + FuelLevel);
                Console.WriteLine("Your total mileage is " + Mileage);
            }
            else
            {
                Console.WriteLine("Sorry you don't have enough fuel to make this trip");
            }
            
        }


    }

}
