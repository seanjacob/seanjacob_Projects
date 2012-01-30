using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Cars
{
    public class Program
    {

        public static decimal FuelLevel { get; set; }
        public static decimal FuelCapacity { get; set; }

        


        public static void Main(string[] args)
        {
            FuelLevel = 0;
            FuelCapacity = 60;
            

            Console.WriteLine("Welcome to my car app. Please see the available commands below");
            Console.WriteLine("add fuel 30.5 (or any amount you want)");
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
                    catch (Exception ex)
                    {
                        Console.Write("Sorry an error occured trying to add the fuel " + ex.Message);
                    }

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


    }

}
