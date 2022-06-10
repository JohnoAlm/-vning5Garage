using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Övning5Garage
{
    public static class Util
    {
        public static string AskForString(string prompt, IUI ui)
        {
            bool success = false;
            string name;

            do
            {
                ui.Print($"{prompt}: ");
                name = ui.GetInput()!;

                if (string.IsNullOrWhiteSpace(name))
                {
                    ui.Print($"You must enter a valid {prompt}");
                }
                
                else
                {
                    success = true;
                }

            } while (!success);

            return name;
        }

        public static int AskForInt(string prompt, IUI ui)
        {
            do
            {
                string input = AskForString(prompt, ui);
                if(int.TryParse(input, out int answer))
                {
                    return answer;
                }

            } while (true);
        }
    }
}
