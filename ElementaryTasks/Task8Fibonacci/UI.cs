using NLog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task8Fibonacci
{
    static class UI
    {

        static bool firstArgParsed;
        static bool secondArgParsed;

        static int leftBorder;
        static int rightBorder;


        public static void GetData(string[] args)
        {
            Logger logger = LogManager.GetCurrentClassLogger();
            if (args.Length == 2)
            {
                Fibonacci_Sequence_Bine fibonacci_Sequence_Bine = new Fibonacci_Sequence_Bine();
                firstArgParsed = int.TryParse(args[0], out leftBorder);
                secondArgParsed = int.TryParse(args[1], out rightBorder);

                if (Validate(firstArgParsed, secondArgParsed))
                {
                    StringBuilder answer = fibonacci_Sequence_Bine.GetFibonacciSequenceString(leftBorder, rightBorder, fibonacci_Sequence_Bine.RangeCalculator(leftBorder, rightBorder));
                    logger.Info(answer);
                    Console.Write(answer);
                }
            }
            else
            {
                logger.Error("Error occured");
                throw new FormatException("Данные введены в неправильном формате, либо количество аргументов больше 2");
            }

            bool Validate(bool firstArgParsed, bool secondArgParsed)
            {

                if (firstArgParsed && secondArgParsed)
                {
                    if (leftBorder > rightBorder)
                    {
                        logger.Error("Error occured");
                        throw new ArgumentOutOfRangeException("Левая граница не может быть больше, чем правая");
                    }
                    return true;
                }
                else
                {
                    logger.Error("Error occured");
                    throw new ArgumentException("Принимаются только числа, строки недопустимы");
                }
                // shift + alt vverh = neskolko strok; shift + home = vvidelit' stroku
            }
        }
        public static StringBuilder StringBuilderLastCharEraser(this StringBuilder stringBuilder, char ch)
        {
            var res = stringBuilder;
            res = res.Remove(res.Length - 1, 1);

            return res;
        }
    }
}
