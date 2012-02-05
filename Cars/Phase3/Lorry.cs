using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Cars.Phase3
{

    public class Lorry : Automobile
    {

        public decimal FuelLevel { get; set; }
        public decimal FuelCapacity { get; set; }
        public decimal Mileage { get; set; }
        public decimal AvgMPG { get; set; }
        public static int Wheels { get; set; }
        public static int Gears { get; set; }
        public int EngineCC { get; set; }
        public int TopSpeed { get; set; }
        public static string Manufacturer { get; set; }
        public static string Model { get; set; }
        public string Info { get; set; }

        public Lorry(bool satnav, string manufacturer, string model) : base(satnav)
        {
            FuelCapacity = 150;
            AvgMPG = 10;
            Manufacturer = manufacturer;
            Model = model;
            Wheels = 6;
            Gears = 6;
            EngineCC = 2000;
            TopSpeed = 120;
        }                

    }
}
