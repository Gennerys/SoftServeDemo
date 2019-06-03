using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task5NumberConverter
{
    static class UI
    {
        public static void GetAnswer(string[] args)
        {
            int result = 0;
            if (Validator.Validate(args, ref result))
            {
                Console.WriteLine(NumberToString.NumeralsToTxt(result, NumberToString.TextCase.Nominative, true, true));
            }
        }

    }
}
