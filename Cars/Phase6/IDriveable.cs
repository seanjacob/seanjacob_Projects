using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Cars.Phase6
{
    public interface IDriveable
    {
        void Drive(int mileageAmount);


    }

    public class Car1 : Automobile, IDriveable
    {

        #region IAutomobile Members

        public void Drive(int mileageAmount)
        {
            throw new NotImplementedException();
        }

        public Car1(Engine engine, bool satnav, string manufacturer, string model, bool locked, string fueltype) : base(engine, satnav, manufacturer, model, locked, fueltype)
        {
            
            FuelCapacity = 70;
            AvgMPG = 30;
            Wheels = 4;
            Gears = 5;                                    
            Engine = engine;
        }

        #endregion
    }
    public class Prog
    {
        public Prog()
        {
            Boat myboat = new Boat();
            Man myMan = new Man(myboat);
            myMan.GoDriving(600);
        }
    }

    public class Man
    {
        public IDriveable WhatImDriving { get; set; }
        
        public Man(IDriveable whatImDriving)
        {
            WhatImDriving = whatImDriving;
        }


        public void GoDriving(int howFar)
        {
            WhatImDriving.Drive(howFar);
        }
    }

    public class Boat : IDriveable
    {

        private void Sail()
        {
            Console.WriteLine("im sailing");
        }



        #region IDriveable Members

        public void Drive(int mileageAmount)
        {
            Sail(mileageAmount);
        }

        #endregion
    }
    public class Plane : IDriveable
    {

        private void Fly()
        {
            Console.WriteLine("im flying");
        }



        #region IDriveable Members

        public void Drive(int mileageAmount)
        {
            Fly();
        }

        #endregion
    }



}
