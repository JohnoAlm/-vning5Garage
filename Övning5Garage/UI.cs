using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Övning5Garage
{
    public class UI : IUI
    {
        public string? GetInput()
        {
            return Console.ReadLine();
        }

        public void Print(string message)
        {
            Console.WriteLine(message);
        }
    }
}
