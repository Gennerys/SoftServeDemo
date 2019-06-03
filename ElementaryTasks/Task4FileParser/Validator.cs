using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Task4FileParser
{
    static class Validator
    {
        public static bool Validate(string path)
        {
            if (Regex.IsMatch(path, @"^(?:[a-zA-Z]\:|\\\\[\w\.]+\\[\w.$]+)\\(?:[\w]+\\)*\w([\w.])+$"))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

    }
}
