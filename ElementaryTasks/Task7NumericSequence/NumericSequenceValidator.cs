using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task7NumericSequence
{
    public static class NumericSequenceValidator
    {
        public static bool Validate(string[] args, ref int result)
        {
            if (args.Length == 0)
            {

                Instruction();
                return false;
            }
            else if (args.Length != 1)
            {
                throw new FormatException("Введено недопустимое количество аргументов");
            }
            else
            {
                bool CheckedArgument;
                //int result;
                CheckedArgument = int.TryParse(args[0], out result);
                if (CheckedArgument)
                {
                    return true;
                }
                else
                {
                    throw new ArgumentException("Неправильный ввод");
                }

            }


        }
        public static StringBuilder StringBuilderLastCharEraser(this StringBuilder stringBuilder, char ch)
        {
            var res = stringBuilder;
            res = res.Remove(res.Length - 1, 1);

            return res;
        }
        private static void Instruction()
        {
            Console.WriteLine("Вам необходимо ввести число, которое больше либо равно 1, вам выведет ряд натуральных чисел, квадрат которых меньше заданного вами числа");
        }
    }
}
