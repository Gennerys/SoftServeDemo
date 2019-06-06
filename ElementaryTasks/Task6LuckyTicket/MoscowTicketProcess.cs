using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task6LuckyTicket
{
    class MoscowTicketProcess : AlgorithmChooser    
    {
        public override bool IsTicketLucky(Ticket ticket)
        {
            bool result = false;
            int firstNumbersSum = 0;
            int secondNumbersSum = 0;

            for (int index = 0; index < ticket.DigitsTicket.Length / 2; index++)
            {
                firstNumbersSum += ticket[index];
                secondNumbersSum += ticket[(ticket.DigitsTicket.Length - 1) - index];
            }
            if (firstNumbersSum == secondNumbersSum)
            {
                result = true;
            }

            return result;
        }
    }
}
