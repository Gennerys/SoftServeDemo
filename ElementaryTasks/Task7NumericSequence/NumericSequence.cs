using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task7NumericSequence
{
    public class NumericSequence
    {
        public IEnumerable<int> GetSequenceMembers(int n)
        {
            if (n <= 1)
            {
                throw new ArgumentOutOfRangeException("Первый аргумент", "Натуральные числа - те, которые используются при счёте, начиная с 1, вводимое число должно быть >= 1");
            }
            int i = 1;

            while (i * i < n)
            {
                yield return i;
                i++;
            }

        }
        public static StringBuilder GetOuputSequence(IEnumerable<int> source)
        {
            StringBuilder result = new StringBuilder(source.Count() * 2);

            foreach (var number in source)
            {
                result.Append(number);
                result.Append(",");
            }

            var temp = NumericSequenceValidator.StringBuilderLastCharEraser(result, ',');
            return temp;


        }
        //Do massiv intov
        // ToString na IEnumarable

    }
}
