using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Cars.Phase2
{
    public class Program2
    {
        public Car MyCar { get; set; }

        public Program2()
        {
            MyCar = new Car();
        }

        public void Run(string command)
        {

            if (command.StartsWith("get info"))
            {
                Console.WriteLine(MyCar.GetInfo());
            }

            else if (command.StartsWith("add fuel")) // Check string
            {
                try
                {
                    decimal fuelAmount = decimal.Parse(command.Replace("add fuel", "").Trim());
                    
                    ReturnValue ret = MyCar.AddFuel(fuelAmount);                    
                    
                    if (ret.Success == true)
                    {
                        Console.WriteLine(ret.Message);
                    }
                    else
                    {
                        Console.WriteLine(ret.Message);
                    }
                }
                catch (Exception)
                {
                    Console.WriteLine("Sorry an error occurred trying to add the fuel \n");
                }

            }
                                
            else if (command.StartsWith("drive"))
            {
                try
                {
                    decimal mileageAmount = decimal.Parse(command.Replace("drive", "").Trim());

                    ReturnValue ret = MyCar.Drive(mileageAmount);
                    
                    if (ret.Success == true)
                    {
                        Console.WriteLine(ret.Message);
                    }
                    else
                    {
                        Console.WriteLine(ret.Message);
                    }
                }
                catch (Exception)
                {
                    Console.WriteLine("Sorry an error occurred trying to add mileage \n");
                }
            }
            
            else
            {
                Console.WriteLine("Sorry I didnt catch that? ");
            }
        }
    }
}
