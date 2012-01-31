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
            Console.WriteLine(MyCar.GetInfo());
            
            ReturnValue ret = MyCar.Drive();
            if (ret.Success == true)
            {
                Console.WriteLine(ret.Message);
            }
            else
            {
                Console.WriteLine(ret.Message);
            }
           
        }
    }
}
