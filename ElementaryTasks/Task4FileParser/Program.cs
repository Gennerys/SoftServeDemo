using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task4FileParser
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                UI.GetOutput(args);
            }
            catch (FormatException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch(FileNotFoundException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch(IOException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
