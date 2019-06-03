using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task4FileParser
{
    static class UI
    {
        public static void GetOutput(string[] args)
        {

            if (args.Length == 2)
            {
                StringCounter stringCounter = new StringCounter();
                Context context = new Context(stringCounter);
                context.ExecuteAlgorithm(args);
            }
            else if (args.Length == 3)
            {
                StringReplacer stringReplacer = new StringReplacer();
                Context context = new Context(stringReplacer);
                context.ExecuteAlgorithm(args);
            }
            else
            {
                throw new FormatException("Некорректное число аргументов");
            }
        }
    }
}
