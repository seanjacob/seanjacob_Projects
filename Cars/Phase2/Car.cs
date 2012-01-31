using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Cars.Phase2
{
    public class Car
    {

        public string GetInfo()
        {
            return ("hi");
        }

        //public int FuelAdded()
        //{
        //}

        public ReturnValue Drive()
        {
            return new ReturnValue(false, "you dont have enough fuel");
            return new ReturnValue(true, "Ive drive 400 miles");
        }
    }
}
