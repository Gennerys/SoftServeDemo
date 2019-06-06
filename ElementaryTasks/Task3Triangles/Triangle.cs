using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task3Triangles
{
    class Triangle
    {
       
        public double FirstSide { get; set; }
        public double SecondSide { get; set; }
        public double ThirdSide { get; set; }
        public double Perimeter { get => FirstSide + SecondSide + ThirdSide; }
        public double HalPeriment { get => Perimeter / 2; }
        public string Name { get; set; }
        public Triangle(double firstSide, double secondSide, double thirdSide, string name)
        {
            FirstSide = firstSide;
            SecondSide = secondSide;
            ThirdSide = thirdSide;
            Name = name;
        }
        public double Square()
        {
            return Math.Sqrt(HalPeriment * (HalPeriment - FirstSide) * (HalPeriment - SecondSide) * (HalPeriment - ThirdSide));   
        }
     


    }
}
