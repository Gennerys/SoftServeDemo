using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task3Triangles
{
    class TriangleComparer : IComparer<Triangle>
    {
        public int Compare(Triangle x, Triangle y)
        {
            int result;

            if(x.Square()>y.Square())
            {
                result = 1;
            }
            else if(x.Square() < y.Square())
            {
                result = -1;
            }
            else
            {
                result = 0;
            }
            return result;

        }
    }
}
