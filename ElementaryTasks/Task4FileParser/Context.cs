using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task4FileParser
{
    class Context
    {
        public IModeParser ContextStrategy { get; set; }

        public Context(IModeParser _mode)
        {
            ContextStrategy = _mode;
        }

        public void ExecuteAlgorithm(string [] args)
        {
            ContextStrategy.ParseAlgortithm(args);
        }
    }
}
