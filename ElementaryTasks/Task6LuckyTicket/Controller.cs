using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task6LuckyTicket
{
    public static class Controller
    {
        static TicketAnalyzer GetTicketAnalyzator(List<string> arguments)
        {
            TicketAnalyzer analyzator = null;

            if (arguments[0].ToUpper() == "MOSCOW")
            {
                analyzator = new TicketAnalyzer(Convert.ToInt32(arguments[1]), Convert.ToInt32(arguments[2]), new MoscowTicketProcess());
            }
            else
            {
                analyzator = new TicketAnalyzer(Convert.ToInt32(arguments[1]), Convert.ToInt32(arguments[2]), new PiterTicketProcess());
            }
            

            return analyzator;
        }

        public static void Run(string[] args)
        {
            string path = InputModel.GetPath(args);
            bool isAllInvalid = true;


            do
            {
                List<string> arguments = InputModel.ReadFile(path);
                if (!Validator.IsArgumentsValid(arguments))
                {
                    
                    path = InputModel.GetPath();
                }
                else
                {
                    TicketAnalyzer analyzator = GetTicketAnalyzator(arguments);
                    UI.ShowCountLuckyTickets(analyzator.CountLuckyTickets());
                    isAllInvalid = false;
                }

            } while (isAllInvalid);
        }
    }
}
