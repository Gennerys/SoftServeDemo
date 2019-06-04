using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task2Envelope
{

    public static class UI
    {        
        public static string InputFromConsole()
        {
            return Console.ReadLine();
        }

        public static void ShowMessage(string message)
        {
             Console.WriteLine(message); 
        }
    }
}
