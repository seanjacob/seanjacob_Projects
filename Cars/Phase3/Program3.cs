using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Cars.Phase3
{
    public class Program3
    {
        public Automobile MyVehical { get; set; }        

        public Program3()
        {
            Console.WriteLine("Are you driving a Car/Lorry?");
            
            string vehicle = Console.ReadLine().ToLower();

            if ((vehicle.Equals("car")) || (vehicle.Equals("lorry")))
            {
                Console.WriteLine("What is the " + vehicle + "'s manufacturer?");
                string manufacturer = Console.ReadLine();

                Console.WriteLine("What is the " + vehicle + "'s model?");
                string model = Console.ReadLine();

                Console.WriteLine("Do you have a sat nav Y/N?");
                string input = Console.ReadLine().ToLower();
                bool satnav = false;
                switch (input)
                {
                    case "y": satnav = true; break;
                    case "n": satnav = false; break;
                    default: Console.WriteLine("Game over."); break;
                }

                switch (vehicle)
                {
                    case "car": MyVehical = new Car(satnav, manufacturer, model); break;
                    case "lorry": MyVehical = new Lorry(satnav, manufacturer, model); break;
                }              
            }
        }

        public void Run(string command)
        {
            if (command.StartsWith("get info"))
            {
                Console.WriteLine(MyVehical.GetInfo());
            }

            else if (command.StartsWith("add fuel")) // Check string
            {
                try
                {

                    while (true)
                    {

                        Console.WriteLine("How much fuel?");

                        string commandAmount = Console.ReadLine();
                        decimal fuelAmount = Decimal.Parse(commandAmount);

                        ReturnValue ret = MyVehical.AddFuel(fuelAmount);

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

                    ReturnValue ret = MyVehical.Plan(mileageAmount);

                    if (ret.Success == true)
                    {
                        Console.WriteLine(ret.Message);
                        string commandDrive = Console.ReadLine().ToLower();
                        if (commandDrive.StartsWith("y"))
                        {
                            Console.WriteLine(MyVehical.Drive(mileageAmount));
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
