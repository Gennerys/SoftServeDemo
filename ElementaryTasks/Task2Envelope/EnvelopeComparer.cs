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
            if (firstEnvelope.EnvelopeHeight < secondEnvelope.EnvelopeHeight &&
                firstEnvelope.EnvelopeWidth < secondEnvelope.EnvelopeWidth)
            {
                return 1;
            }
            else if (firstEnvelope.EnvelopeHeight == secondEnvelope.EnvelopeHeight && 
                     firstEnvelope.EnvelopeWidth == secondEnvelope.EnvelopeWidth) 
                 {
                     return 0;
                 }
           
            else
            { return -1; }
            
        }
    }
}
