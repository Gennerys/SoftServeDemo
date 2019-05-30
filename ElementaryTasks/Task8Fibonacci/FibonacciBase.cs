using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task8Fibonacci
{
    abstract class FibonacciBase
    {
        public abstract double Fibonacci(double n);
        public abstract IEnumerable<double> RangeCalculator(int leftBorder, int rightBorder);
    }
}
