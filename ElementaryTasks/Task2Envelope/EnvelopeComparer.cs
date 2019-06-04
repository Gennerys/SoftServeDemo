using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task2Envelope
{
    class EnvelopeComparer<T> : IComparer<T> where T : Envelope
    {
        public int Compare(T firstEnvelope, T secondEnvelope)
        {
            int result;

            if (firstEnvelope.Height < secondEnvelope.Height &&
                firstEnvelope.Width < secondEnvelope.Width)
            {
                result = 1;
            }
            else if (firstEnvelope.Height == secondEnvelope.Height &&
                     firstEnvelope.Width == secondEnvelope.Width)
                 {
                     result = 0;
                 }
            else
            {
                result = -1;
            }
            return result;
        }
    }
}
