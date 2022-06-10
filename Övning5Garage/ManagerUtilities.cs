using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Övning5Garage
{
    public static class ManagerUtilities
    {
        // Här bryts Managers AddVehicle metod upp i flera olika statiska metoder som tar hand om text, inputs och att lägga till fordon

        // Lägger till fordonets fordonstyp
        public static string AddVehicleType(IUI ui)
        {
            ui.Print("\nPlease enter the vehicle type of which you would like to add: ");
            ui.Print("\n1. Vehicle\n2. Airplane\n3. Motorcycle\n4. Car\n5. Bus\n6. Boat");
            string vehicleType = Util.AskForString("\nVehicle type", ui);

            return vehicleType;
        }
        // Lägger till registreringsnummret
        public static string AddRegNum(IUI ui)
        {
            ui.Print($"\nPlease enter the registration number");
            string regNum = Util.AskForString("\nRegistration number", ui).ToUpper();
            
            return regNum;
        }
        // Lägger till färgen
        public static string AddColor(IUI ui)
        {
            string[] allowedColors = new string[] { "red", "green", "blue", "yellow", "orange", "pink", "purple", "brown", "grey", "black", "white" };
            
            ui.Print($"\nPlease enter the color");
            ui.Print($"\nValid colors");
            foreach (var colorValue in allowedColors)
            {
                ui.Print(colorValue);
            }
            string color = Util.AskForString("\nColor", ui).ToLower();
            
            while (!allowedColors.Contains(color))
            {
                ui.Print($"\nYou must enter a valid color!");
                color = Util.AskForString("\nColor", ui).ToLower();
            }
            return color;
        }
        // Lägger till antal hjul på fordonet
        public static int AddNumOfWheels(IUI ui)
        {
            ui.Print($"\nPlease enter the number of wheels");
            int numOfWheels = Util.AskForInt("\nNumber of wheels", ui);
            
            return numOfWheels;
        }

        public static Vehicle CreateVehicle(IUI ui, string regNum, string color, int numOfWheels)
        {
            return new Vehicle(regNum, color, numOfWheels);
        }

        // Här skapas alla olika fordonstyper eller subklasser utifrån de generella egenskaperna men skiljs åt med deras unika egenskaper som användaren måste ange
        public static Airplane CreateAirplane(IUI ui, string regNum, string color, int numOfWheels)
        {
            ui.Print($"\nPlease enter the number of engines on the Airplane ");
            int numOfEngines = Util.AskForInt("\nNumber of engines", ui);

            ui.Print($"\nPlease enter the wingspan of the Airplane (in metres) ");
            int wingspan = Util.AskForInt("\nWingspan", ui);

            return new Airplane(regNum, color, numOfWheels, numOfEngines, wingspan);
        }
        
        public static Motorcycle CreateMotorcycle(IUI ui, string regNum, string color, int numOfWheels)
        {
            ui.Print($"\nPlease enter the engine displacement of the Motorcycle ");
            int engineDisplacement = Util.AskForInt("\nEngine displacement", ui);

            return new Motorcycle(regNum, color, numOfWheels, engineDisplacement);
        }

        public static Car CreateCar(IUI ui, string regNum, string color, int numOfWheels)
        {
            ui.Print($"\nPlease enter the fuel type of the Car");
            ui.Print($"1. Petrol95");
            ui.Print($"2. Petrol98");
            ui.Print($"3. Diesel");
            string fuelType = Util.AskForString("Fuel type", ui);

            Car car = null;

            switch (fuelType)
            {
                case "1":
                    car =  new Car(regNum, color, numOfWheels, FuelType.Petrol95);
                    break;
                case "2":
                     car = new Car(regNum, color, numOfWheels, FuelType.Petrol98);
                    break;
                case "3":
                     car = new Car(regNum, color, numOfWheels, FuelType.Diesel);
                    break;
                default:

                    break;
            }
            return car; 
        }

        public static Bus CreateBus(IUI ui, string regNum, string color, int numOfWheels)
        {
            ui.Print($"\nPlease enter the number of seats in the Bus");
            int numOfSeats = Util.AskForInt("\nNumber of seats", ui);

            return new Bus(regNum, color, numOfWheels, numOfSeats);
        }

        public static Boat CreateBoat(IUI ui, string regNum, string color, int numOfWheels)
        {
            ui.Print($"\nPlease enter the length of the Boat (in centimetres): ");
            int length = Util.AskForInt("\nLength", ui);

            return new Boat(regNum, color, numOfWheels, length);
        }

        public static void RemoveVehicle(IUI ui, IHandler handler)
        {
            try
            {
                var vehicles = handler.GetAllVehicles();
                ui.Print("\nEnter the ID of the vehicle you want to remove");
                int selectedId = Util.AskForInt("\nID", ui);
                Vehicle selectedVehicle = vehicles[selectedId];
                ui.Print(selectedVehicle.DisplayVehicleDetails());
                ui.Print("\nDo you want to remove this vehicle?\n\n1. Yes\n2. No");
                var removeVehicleInput = Util.AskForString("\nInput", ui);

                switch (removeVehicleInput)
                {
                    case "1":
                        handler.Remove(selectedVehicle);
                        ui.Print("\nVehicle removed successfully!");
                        break;

                    case "2":
                        break;
                }

                }
            catch (ArgumentOutOfRangeException ex)
            {
                ui.Print(ex.Message);
            }
        }

        public static void ListAllVehicleTypes(IUI ui, IHandler handler)
        {
            ui.Print("\nVehicle types in garage\n");

            var vehicles = handler.GetAllVehicles().OfType<Vehicle>().Where(v => v.GetType() == typeof(Vehicle)).Count();
            ui.Print($"Number of Vehicles (Other vehicles of unassigned types): {vehicles}");

            var airplanes = handler.GetAllVehicles().OfType<Airplane>().Count();
            ui.Print($"Number of Airplanes: {airplanes}");

            var motorcycles = handler.GetAllVehicles().OfType<Motorcycle>().Count();
            ui.Print($"Number of Motorcycles: {motorcycles}");

            var cars = handler.GetAllVehicles().OfType<Car>().Count();
            ui.Print($"Number of Cars: {cars}");

            var buses = handler.GetAllVehicles().OfType<Bus>().Count();
            ui.Print($"Number of Buses: {buses}");

            var boats = handler.GetAllVehicles().OfType<Boat>().Count();
            ui.Print($"Number of Boats: {boats}");
        }

        public static void SearchForVehicles(IUI ui, IHandler handler)
        {
            do
            {
                var vehicles = handler.GetAllVehicles();
                ui.Print("\nWhich property do you want to filter by to search?\n1. Vehicle type\n2. Registration number\n3. Color\n4. Number of wheels\n0. Exit Search");
                string input = Util.AskForString("\ninput", ui);


                switch (input)
                {
                    case "1":
                        ui.Print("\nSelect a vehicle type to filter by\n1. Vehicle\n2. Airplane\n3. Motorcycle\n4. Car\n5. Bus\n6. Boat");
                        var vehicleType = Util.AskForString("\nVehicle type", ui);

                        switch (vehicleType)
                        {
                            case "1":
                                vehicles.OfType<Vehicle>().Where(v => v.GetType() == typeof(Vehicle)).ToList().ForEach(v => ui.Print(v.DisplayVehicleDetails()));
                                break;

                            case "2":
                                vehicles.OfType<Airplane>().ToList().ForEach(v => ui.Print(v.DisplayVehicleDetails()));

                                break;
                            case "3":
                                vehicles.OfType<Motorcycle>().ToList().ForEach(v => ui.Print(v.DisplayVehicleDetails()));

                                break;
                            case "4":
                                vehicles.OfType<Car>().ToList().ForEach(v => ui.Print(v.DisplayVehicleDetails()));

                                break;
                            case "5":
                                vehicles.OfType<Bus>().ToList().ForEach(v => ui.Print(v.DisplayVehicleDetails()));

                                break;
                            case "6":
                                vehicles.OfType<Boat>().ToList().ForEach(v => ui.Print(v.DisplayVehicleDetails()));

                                break;
                        }
                        break;

                    case "2":
                        var regNum = Util.AskForString("Registration number", ui).ToUpper();
                        vehicles.Where(v => v.RegNum == regNum).ToList().ForEach(v => ui.Print(v.DisplayVehicleDetails()));
                        break;

                    case "3":
                        var color = Util.AskForString("Color", ui);
                        vehicles.Where(v => v.Color == color).ToList().ForEach(v => ui.Print(v.DisplayVehicleDetails()));
                        break;

                    case "4":
                        var numOfWheels = Util.AskForInt("Number of wheels", ui);
                        vehicles.Where(v => v.NumOfWheels == numOfWheels).ToList().ForEach(v => ui.Print(v.DisplayVehicleDetails()));
                        break;

                    case "0":

                        return;
                }

            } while (true);
        }
    }
}
