using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task2Envelope
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                do
                {
                    Controller.ConfirmValidation();
                }
                while (Controller.ContinueWork());

            }
            catch (FormatException ex)
            {
                Console.WriteLine(ex.Message);
            }

        }

    }
}
