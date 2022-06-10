using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Övning5Garage
{
    public class Bus : Vehicle
    {
        public int NumOfSeats { get; set; }
        public Bus(string regNum, string color, int numOfWheels, int numOfSeats) : base(regNum, color, numOfWheels)
        {
            NumOfSeats = numOfSeats;
        }
        public override string DisplayVehicleDetails()
        {
            return $"\nBus\n___________\nRegistration number: {RegNum}\nColor: {Color}\nNumber of wheels: {NumOfWheels}\nNumber of seats: {NumOfSeats}";
        }
    }
}
