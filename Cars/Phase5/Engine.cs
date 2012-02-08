using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Cars.Phase5
{

    public class Engine
    {
        public const int SERVICE_INTERVAL = 600;
        
        public int EngineCC { get; set; }
        public decimal Mileage { get; set; }
        public bool ServiceNeeded { get; set; }
        public decimal ServiceCounter { get; set; }

        public Engine(int enginecc)
        {            
            EngineCC = enginecc;
        }

        public string AddMileage(decimal mileageAmount)
        {
            Mileage += mileageAmount;
            ServiceCounter += mileageAmount;

            if (ServiceCounter >= SERVICE_INTERVAL)
            {
                ServiceNeeded = true;
            }

            return "You have driven " + mileageAmount + " miles. Total vehicle mileage " + Mileage + "\n";
        }

        public string Service()
        {
            ServiceCounter = 0;
            ServiceNeeded = false;
            return "Your vehicle has been service.\n";
        }

    }
}
