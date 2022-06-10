using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Övning5Garage
{
    public class Car : Vehicle
    {
        public FuelType FuelType { get; set; }
      
        public Car(string regNum, string color, int numOfWheels, FuelType fuelType) : base(regNum, color, numOfWheels)
        {
            FuelType = fuelType;
            
        }
        public override string DisplayVehicleDetails()
        {
            return $"\nCar\n___________\nRegistration number: {RegNum}\nColor: {Color}\nNumber of wheels: {NumOfWheels}\nFuel type: {FuelType}";
        }
    }
}
