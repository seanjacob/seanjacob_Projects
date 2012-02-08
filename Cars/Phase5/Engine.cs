using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Cars.Phase5
{

    public class Engine
    {

        public int EngineCC { get; set; }
        public decimal Mileage { get; set; }

        public Engine(int enginecc)
        {            
            EngineCC = enginecc;
        }
        

    }
}
