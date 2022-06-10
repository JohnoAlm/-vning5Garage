using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Övning5Garage
{
    public class Vehicle
    {
        private string _regNum;
        private string _color;
        private int _numOfWheels;

        public string RegNum { get { return _regNum; } set { _regNum = value; } }
        public string Color { get { return _color; } set { _color = value; } }
        public int NumOfWheels { get { return _numOfWheels; } set { _numOfWheels = value; } }
        

        public Vehicle(string regNum, string color, int numOfWheels)
        {
            RegNum = regNum;
            Color = color;
            NumOfWheels = numOfWheels;
            
           
        }

        public virtual string DisplayVehicleDetails()
        {
            return $"\nVehicle\n___________\nRegistration number: {RegNum}\nColor: {Color}\nNumber of wheels: {NumOfWheels}";
        }
    }
}
