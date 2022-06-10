using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Övning5Garage
{
    public class Motorcycle : Vehicle
    {
        public int EngineDisplacement { get; set; }
        public Motorcycle(string regNum, string color, int numOfWheels, int engineDisplacement) : base(regNum, color, numOfWheels)
        {
            EngineDisplacement = engineDisplacement;
        }
        public override string DisplayVehicleDetails()
        {
            return $"\nMotorcycle\n___________\nRegistration number: {RegNum}\nColor: {Color}\nNumber of wheels: {NumOfWheels}\nEngine displacement: {EngineDisplacement} cc";
        }
    }
}
