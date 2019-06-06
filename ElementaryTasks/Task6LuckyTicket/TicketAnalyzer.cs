using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NLog;
namespace Task6LuckyTicket
{
    class TicketAnalyzer
    {

        #region Fields

        private int _startNumberRange;
        private int _finishNumberRange;
        private int _countLuckyTickets = 0;
        private int _countDigitsInTicket = 6;
        private readonly AlgorithmChooser _ticketAlgorithm;
        Logger logger = LogManager.GetCurrentClassLogger();

        #endregion

        #region Constructors

        public TicketAnalyzer(int startNumberRange, int finishNumberRange, AlgorithmChooser algorithm)
        {
            StartNumberRange = startNumberRange;
            FinishNumberRange = finishNumberRange;
            _ticketAlgorithm = algorithm;

        }

        #endregion

        #region Properties

        public AlgorithmChooser GetAlgorithmLuckyTickets { get => _ticketAlgorithm; }
        public int StartNumberRange
        {
            get
            {
                return _startNumberRange;
            }
            set
            {
                if (value < 1)
                {
                    logger.Error("Error occured");
                    throw new ArgumentOutOfRangeException("Value can`t be less than one");
                }
                else
                {
                    _startNumberRange = value;
                }
            }
        }
        public int FinishNumberRange
        {
            get
            {
                return _finishNumberRange;
            }
            set
            {
                if (value < 1 || value < StartNumberRange)
                {
                    logger.Error("Error occured");
                    throw new ArgumentOutOfRangeException(value < 0 ? "Value can`t be less than one" : "Finish number can`t be less than start");
                }
                else
                {
                    _finishNumberRange = value;
                }
            }
        }

        #endregion


        #region Methods

        public int CountLuckyTickets()
        {
            _countLuckyTickets = 0;

            for (int indexer = StartNumberRange; indexer <= FinishNumberRange; indexer++)
            {
                if (GetAlgorithmLuckyTickets.IsTicketLucky(new Ticket(indexer, _countDigitsInTicket)))
                {
                    _countLuckyTickets++;
                }
            }

            return _countLuckyTickets;
        }


        #endregion

    }
}
