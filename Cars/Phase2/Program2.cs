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
            //MyCar = new Car();
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
                    //decimal fuelAmount = decimal.Parse(command.Replace("add fuel", "").Trim());

                    while (true)
                    {

                        Console.WriteLine("How much fuel?");

                        string commandAmount = Console.ReadLine();
                        decimal fuelAmount = Decimal.Parse(commandAmount);

                        ReturnValue ret = MyCar.AddFuel(fuelAmount);

                        if (ret.Success == true)
                        {
                            Console.WriteLine(ret.Message);
                            break;
                        }
                        else
                        {
                            Console.WriteLine(ret.Message);
                            string commandRetry = Console.ReadLine().ToLower();
                            if (commandRetry.StartsWith("n"))
                            {
                                Console.WriteLine("Ok then. \n");
                                break;
                            }
                        }
                    }
                }
                catch (Exception)
                {
                    Console.WriteLine("Sorry an error occurred trying to add the fuel. \n");
                }

            }
                                
            else if (command.StartsWith("plan"))
            {
                try
                {                    
                    Console.WriteLine("How many miles?");

                    string commandAmount = Console.ReadLine();
                    decimal mileageAmount = Decimal.Parse(commandAmount);
                    
                    ReturnValue ret = MyCar.Plan(mileageAmount);
                    
                    if (ret.Success == true)
                    {
                        Console.WriteLine(ret.Message);
                        string commandDrive = Console.ReadLine().ToLower();
                        if (commandDrive.StartsWith("y"))
                        {
                            Console.WriteLine(MyCar.Drive(mileageAmount));
                        }
                        else
                        {
                            Console.WriteLine("Ok then. \n");
                        }
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
                Console.WriteLine("Sorry I didn't catch that? \n");
            }
        }
    }
}
