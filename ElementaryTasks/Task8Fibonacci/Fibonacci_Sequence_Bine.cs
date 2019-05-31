using NLog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task8Fibonacci
{
    class Fibonacci_Sequence_Bine:FibonacciBase
    {
        Logger logger = LogManager.GetCurrentClassLogger();
        //Fibonacci by Bine
        public override double Fibonacci(double n)
        {
            double result = 0;

            double index = Math.Pow(5, 0.5);

            double leftNumber = (1 + index) / 2;
            double rightNumber = (1 - index) / 2;

            result = Math.Round((Math.Pow(leftNumber, n) - Math.Pow(rightNumber, n)) / index);

            //Logger logger = LogManager.GetCurrentClassLogger();

            logger.Info(result);

            return result;
        }

        public override IEnumerable<double> RangeCalculator(int leftBorder, int rightBorder)
        {
            //int i = leftBorder;
            double result = Fibonacci(leftBorder);
            for (int j = leftBorder; j <= rightBorder; j++)
            {

                result = Fibonacci(j);
                if (result >= rightBorder) { break; }

                yield return result;


            }

        }
        public StringBuilder GetFibonacciSequenceString(int leftBorder, int rightBorder, IEnumerable<double> source)
        {

            //Logger logger = LogManager.GetCurrentClassLogger();
            StringBuilder result = new StringBuilder();
            foreach (var number in source)
            {
                result.Append(number + ",");
            }

            var temp = UI.StringBuilderLastCharEraser(result, ',');
            logger.Info(temp);
            return temp;

        }
    }
}
