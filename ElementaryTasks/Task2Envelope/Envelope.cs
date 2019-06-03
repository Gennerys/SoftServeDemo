using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task2Envelope
{
    class Envelope
    {
       public double EnvelopeHeight
        { get; set; }

        public double EnvelopeWidth
        { get; set; }

        public Envelope(double height,double width)
        {
            EnvelopeHeight = height;
            EnvelopeWidth = width;
        }
    }
}
