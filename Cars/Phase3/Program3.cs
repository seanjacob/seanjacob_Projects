using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Cars.Phase3
{
    public class Program3
    {        
        public Car MyCar { get; set; }
        public Lorry MyLorry { get; set; }
        public AutomobileType CurrentAutomobile { get; set; }
        public enum AutomobileType 
        { 
            Car,
            Lorry
        } 

        public Program3()
        {          
            MyCar = new Car(true, "Citroen", "Saxo");
            MyLorry = new Lorry(true, "Mercades", "Actros");

            CurrentAutomobile = AutomobileType.Car;            
        }

        public Automobile GetAutomobile()
        {
            switch (CurrentAutomobile)
            {
                case AutomobileType.Car : return MyCar;
                case AutomobileType.Lorry : return MyLorry;
                default : return MyCar;
            }

        }

        public void Run(string command)
        {            

            if (command.StartsWith("switch"))
            {
                switch (CurrentAutomobile)
                {
                    case AutomobileType.Car : CurrentAutomobile = AutomobileType.Lorry;
                        Console.WriteLine("You have switched to a Lorry\n");
                        break;
                    case AutomobileType.Lorry: CurrentAutomobile = AutomobileType.Car;
                        Console.WriteLine("You have switched to a Car\n");
                        break;
                }                                
            }

            else if (command.StartsWith("get info"))
            {
                Console.WriteLine(GetAutomobile().GetInfo());
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

                        ReturnValue ret = GetAutomobile().AddFuel(fuelAmount);

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

                    ReturnValue ret = GetAutomobile().Plan(mileageAmount);

                    if (ret.Success == true)
                    {
                        Console.WriteLine(ret.Message);
                        string commandDrive = Console.ReadLine().ToLower();
                        if (commandDrive.StartsWith("y"))
                        {
                            Console.WriteLine(GetAutomobile().Drive(mileageAmount));
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
