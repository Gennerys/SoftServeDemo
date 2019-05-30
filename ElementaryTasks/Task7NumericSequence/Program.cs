using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task7NumericSequence
{
    class Program
    {
        static void Main(string[] args)
        {
            //zapuskat; v cikle poka ne true, esli ne ok kidat false
            try
            {
                NumericUI.GetAnswer(args);
            }
            catch (FormatException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (ArgumentOutOfRangeException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (ArithmeticException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            // Nekorekniy vvod - vvesti zanovo argumenti
        }
    }
}
