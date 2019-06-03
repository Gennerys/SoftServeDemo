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

                while (UI.isWorking)
                {
                    if (UI.GetAnswer())
                    {
                        UI.CheckResults();
                    }
                    else
                    {
                        if (UI.GetAnswer())
                        {
                            UI.CheckResults();
                        }

                    }
                }
            }
            catch (FormatException ex)
            {
                Console.WriteLine(ex.Message);

            }
            
        }

    }
}
