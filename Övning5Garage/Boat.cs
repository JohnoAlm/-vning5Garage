using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Övning5Garage
{
    public class Boat : Vehicle
    {
        public int Length { get; set; }

        public Boat(string regNum, string color, int numOfWheels, int length) : base(regNum, color, numOfWheels)
        {
            Length = length;
        }
        public override string DisplayVehicleDetails()
        {
            return $"\nBoat\n___________\nRegistration number: {RegNum}\nColor: {Color}\nNumber of wheels: {NumOfWheels}\nLength: {Length} cm";
        }
    }
}
