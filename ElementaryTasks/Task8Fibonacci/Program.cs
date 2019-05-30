using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task8Fibonacci
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                UI.GetData(args);
            }
            catch (ArgumentOutOfRangeException ex)
            {

                Console.WriteLine(ex.Message);
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (FormatException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
