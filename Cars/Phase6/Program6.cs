using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Cars.Phase6
{
    public class Program6
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

        public Program6()
        {
            Engine myHatchbackEngine = new Engine(1400);
            MyHatchback = new Hatchback(myHatchbackEngine, true, "Citroen", "Saxo", true, "petrol");

            Engine mySaloonEngine = new Engine(1800);
            MySaloon = new Saloon(mySaloonEngine, true, "Audi", "A3", true, "diesel");
            
            Engine myLorryEngine = new Engine(2000);
            MyLorry = new Lorry(myLorryEngine, true, "Mercades", "Actros", true, "petrol");

            Stig myStig = new Stig(MyHatchback);
            myStig.GoDriving(600);
        }        
    }
}
