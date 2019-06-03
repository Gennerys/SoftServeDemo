using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task5NumberConverter
{
    static class Validator
    {
        private static void Instruction()
        {
            Console.WriteLine("Вам необходимо ввести неотрицательное число");
        }

        public static bool Validate(string [] args,ref int result)
        {
            if(args.Length == 0)
            {
                Instruction();
                return false;
            }
            if(args.Length==1)
            {
                bool isGoodArgument;
                isGoodArgument = int.TryParse(args[0], out result);
                if (isGoodArgument)
                {
                    return true;
                }
                else
                {
                    throw new ArgumentException("Неправильный тип числа, допустимые только целочисленные");

                }
            }
            else
            {
                throw new FormatException("Неправильный ввод");
            }
            
        }

    }
}
