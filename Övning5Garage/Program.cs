using System;

namespace Övning5Garage
{
    internal class Program
    {
        static void Main(string[] args)
        {
            
            // Använd LINQ för att söka efter fordon utifrån en egenskap


            //               -> Manager behöver kanske ett (IUI)UI
            //              |
            // Program -> Manager
            //              |
            //               -> (IHandler)Handler -> (IGarage)Garaget


            //Program instanserar manager, manager instanserar handler, handler instanserar garaget

            // När vi använder interface så slipper vi beroenden

            // Deferred execution

            // Använd Where alltså LINQ

            IUI ui = new UI();
            var manager = new Manager(ui);
            manager.Start();
        }
    }
}
