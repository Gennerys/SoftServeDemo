using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task6LuckyTicket
{
    public class Context
    {
        public ILuckyTicket ContextStrategy { get; set; }

        public Context(ILuckyTicket _luckyTicket)
        {
            ContextStrategy = _luckyTicket;
        }

        public void ExecuteAlgorithm()
        {
            ContextStrategy.IsLuckyTicket();
        }




    }
}
