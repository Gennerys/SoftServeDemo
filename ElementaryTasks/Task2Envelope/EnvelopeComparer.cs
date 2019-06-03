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
            if (firstEnvelope.Height < secondEnvelope.Height &&
                firstEnvelope.Width < secondEnvelope.Width)
            {
                return 1;
            }
            else if (firstEnvelope.Height == secondEnvelope.Height && 
                     firstEnvelope.Width == secondEnvelope.Width) 
                 {
                     return 0;
                 }
           
            else
            { return -1; }
            
        }
    }
}
