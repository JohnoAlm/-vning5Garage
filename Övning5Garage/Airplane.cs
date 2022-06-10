using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Övning5Garage
{
    public class Airplane : Vehicle
    {
        public int NumOfEngines { get; set; }
        public int Wingspan { get; set; }
        public Airplane(string regNum, string color, int numOfWheels, int numOfEngines, int wingspan) : base(regNum, color, numOfWheels)
        {
            NumOfEngines = numOfEngines;
            Wingspan = wingspan;
        }
        public override string DisplayVehicleDetails()
        {
            return $"\nAirplane\n___________\nRegistration number: {RegNum}\nColor: {Color}\nNumber of wheels: {NumOfWheels}\nNumber of engines: {NumOfEngines}\nWingspan: {Wingspan} m";
        }
    }
}
