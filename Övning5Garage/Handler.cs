using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Övning5Garage
{
    public class Handler : IHandler
    {
        private IGarage<Vehicle> garage;

        public Handler(int capacity)
        {
            garage = new Garage<Vehicle>(capacity);
        }

        public void Add(Vehicle item)
        {
            garage.Add(item);
        }

        public void Remove(Vehicle item)
        {
            garage.Remove(item);
        }

        public List<Vehicle> GetAllVehicles()
        {
            return garage.ToList();
        }
    } 
}

