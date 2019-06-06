using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task3Triangles
{
    class Program
    {
        static void Main(string[] args)
        {
            Triangle triangle = new Triangle(10, 20, 25);
            Triangle triangle1 = new Triangle(5, 6, 7);
            Console.WriteLine(triangle.Square());
            Console.WriteLine(triangle1.Square());
           
        }
    }
}
