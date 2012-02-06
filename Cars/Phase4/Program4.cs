using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Cars.Phase4
{
    public class Program4
    {        
        public Hatchback MyHatchback { get; set; }
        public Saloon MySaloon { get; set; }
        public Lorry MyLorry { get; set; }
        public AutomobileType CurrentAutomobile { get; set; }
        public enum AutomobileType 
        { 
            Hatchback,
            Saloon,
            Lorry
        } 

        public Program4()
        {          
            MyHatchback = new Hatchback(true, "Citroen", "Saxo", true);
            MySaloon = new Saloon(true, "Audi", "A3", true);
            MyLorry = new Lorry(true, "Mercades", "Actros", true);

            CurrentAutomobile = AutomobileType.Hatchback;
        }

        public Automobile GetAutomobile()
        {
            switch (CurrentAutomobile)
            {
                case AutomobileType.Hatchback : return MyHatchback;
                case AutomobileType.Saloon: return MySaloon;
                case AutomobileType.Lorry : return MyLorry;
                default : return MyHatchback;
            }

        }

        public void Run(string command)
        {            

            if (command.StartsWith("switch"))
            {
                switch (CurrentAutomobile)
                {
                    case AutomobileType.Hatchback : CurrentAutomobile = AutomobileType.Saloon;
                        Console.WriteLine("You have switched to a Saloon\n");
                        break;
                    case AutomobileType.Saloon: CurrentAutomobile = AutomobileType.Lorry;
                        Console.WriteLine("You have switched to a Lorry\n");
                        break;
                    case AutomobileType.Lorry: CurrentAutomobile = AutomobileType.Hatchback;
                        Console.WriteLine("You have switched to a Hatchback\n");
                        break;
                }                                
            }

            else if (command.StartsWith("get info"))
            {                
                Console.WriteLine(GetAutomobile().GetInfo());
            }

            else if (command.StartsWith("lock"))
            {
                ReturnValue ret = GetAutomobile().Lock();
                if (ret.Success) Console.WriteLine(ret.Message);
            }

            else if (command.StartsWith("unlock"))
            {
                if (CurrentAutomobile == AutomobileType.Hatchback)
                {
                    ReturnValue ret = MyHatchback.Unlock();
                    if (ret.Success) Console.WriteLine(ret.Message);
                }
                else if (CurrentAutomobile == AutomobileType.Saloon)
                {
                    Console.WriteLine("Please provide a code."); ;
                    string code = Console.ReadLine().ToLower();                    
                    ReturnValue ret = MySaloon.Unlock(code);
                    if (ret.Success) Console.WriteLine(ret.Message);
                }

                else if (CurrentAutomobile == AutomobileType.Lorry)
                {
                    ReturnValue ret = MyLorry.Unlock();
                    if (ret.Success) Console.WriteLine(ret.Message);
                }
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
                            if(GetAutomobile().Locked.Equals(false))
                            {
                                Console.WriteLine(GetAutomobile().Drive(mileageAmount));
                            }
                            else
                            {
                                Console.WriteLine("You need to unlock your " + CurrentAutomobile + ".\n");
                            }
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
