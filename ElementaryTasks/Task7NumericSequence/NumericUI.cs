using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task7NumericSequence
{
    static class NumericUI
    {
        public static void GetAnswer(string[] args)
        {
            int result = 0;
            if (NumericSequenceValidator.Validate(args, ref result))
            {
                //int result = int.Parse(args[0]);
                NumericSequence numericSequence = new NumericSequence();
                StringBuilder answer = NumericSequence.GetOuputSequence(numericSequence.GetSequenceMembers(result));
                Console.Write(answer);
            }
        }
    }
}
