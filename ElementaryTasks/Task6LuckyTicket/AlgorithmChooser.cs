using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task6LuckyTicket
{
    abstract class AlgorithmChooser
    {
       public abstract bool IsTicketLucky(Ticket ticket);
    }
}
