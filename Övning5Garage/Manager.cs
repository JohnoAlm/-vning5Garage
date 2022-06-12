using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Övning5Garage
{
    internal class Manager
    {
       
        private IUI _ui;
       
        public Manager(IUI ui)
        {
            _ui = ui;
        }
        
        internal void Start()
        {
            // Först skapas garaget
            IHandler handler = CreateGarageHandler();

            do
            {
                // Efter det skapas main menu alltså huvudmenyn
                MainMenu();
                // Därefter lägger vi vårat nyligen skapade garage i MainMenuOptions som då kan använda det för att utföra olika handlingar
                MainMenuInput(handler);

            } while (true);
        }

        private IHandler CreateGarageHandler()
        {
            _ui.Print("Welcome to your garage!");
            _ui.Print("\nPlease create the new garage by entering an amount of parking spaces\n");
            int capacity = Util.AskForInt("Parking spaces", _ui);
            if(capacity < 2)
            {
                _ui.Print("You can't set the amount of parking spaces below 2! A default value of 2 parking spaces has been set");
            }
            else
            {
                _ui.Print($"\nGarage created successfully with {capacity} parking spaces!");
            }
            IHandler handler = new Handler(capacity);
            return handler;
        }

        private void AddVehicle(IHandler handler)
        {
            var vehicleType = ManagerUtilities.AddVehicleType(_ui);

            var regNum = ManagerUtilities.AddRegNum(_ui);

            var color = ManagerUtilities.AddColor(_ui);

            var numOfWheels = ManagerUtilities.AddNumOfWheels(_ui);

            Vehicle vehicle = null;

            switch (vehicleType)
            {
                case "1":
                    vehicle = ManagerUtilities.CreateVehicle(_ui, regNum, color, numOfWheels);
                    break;
                case "2":
                    vehicle = ManagerUtilities.CreateAirplane(_ui, regNum, color, numOfWheels);
                    break;
                case "3":
                    vehicle = ManagerUtilities.CreateMotorcycle(_ui, regNum, color, numOfWheels);
                    break;
                case "4":
                    vehicle = ManagerUtilities.CreateCar(_ui, regNum, color, numOfWheels);   
                    break;
                case "5":
                    vehicle = ManagerUtilities.CreateBus(_ui, regNum, color, numOfWheels);
                    break;
                case "6":
                    vehicle = ManagerUtilities.CreateBoat(_ui, regNum, color, numOfWheels);
                    break;
                default:

                    break;
            }
            handler.Add(vehicle);
            _ui.Print("Vehicle added successfully!");
        }

        private void RemoveVehicle(IHandler handler)
        {
            ManagerUtilities.RemoveVehicle(_ui, handler);
        }

        private void ListAllVehicles(IHandler handler)
        {
            handler.GetAllVehicles().ForEach(v => _ui.Print(v.DisplayVehicleDetails()));
        }

        private void ListAllVehicleTypes(IHandler handler)
        {
            ManagerUtilities.ListAllVehicleTypes(_ui, handler);
        }

        private void SearchForVehicles(IHandler handler)
        {
            ManagerUtilities.SearchForVehicles(_ui, handler);
        }

        private void Quit()
        {
            Console.WriteLine("\nThanks for using this application!");
            System.Environment.Exit(0);
        }

        private void MainMenu()
        {
            _ui.Print("\nPlease select an option to interact with the garage:\n ");
            _ui.Print("1. Add vehicle");
            _ui.Print("2. Remove vehicle");
            _ui.Print("3. List all vehicles");
            _ui.Print("4. List all vehicle types");
            _ui.Print("5. Search for vehicles");
            _ui.Print("0. Quit");
        }

        private void MainMenuInput(IHandler handler)
        {
            string input = _ui.GetInput();

            switch (input)
            {
                case "1":
                    AddVehicle(handler);
                    break;
                case "2":
                    RemoveVehicle(handler);
                    break;
                case "3":
                    ListAllVehicles(handler);
                    break;
                case "4":
                    ListAllVehicleTypes(handler);
                    break;
                case "5":
                    SearchForVehicles(handler);
                    break;
                case "0":
                    Quit();
                    break;
                default:
                    break;
            }
        }
    }
}
