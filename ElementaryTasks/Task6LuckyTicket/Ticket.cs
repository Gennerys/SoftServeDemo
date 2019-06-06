using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task6LuckyTicket
{
     class Ticket
    {
        #region Indexator, Fields, Properties

        private readonly int[] _numberTicket;

        public int[] DigitsTicket { get => _numberTicket; }

        public int this[int index]
        {
            get
            {
                return DigitsTicket[index];
            }
        }

        #endregion


        public static int[] CreateArrayWithDigits(int number, int quantityDigitsInNumber, int countDigitsInTicket)
        {
            int[] arrayDigits = new int[countDigitsInTicket];

            for (int index = 0; index < countDigitsInTicket - quantityDigitsInNumber; index++)
            {
                arrayDigits[index] = 0;
            }

            string stringNumber = Convert.ToString(number);

            for (int index = countDigitsInTicket - quantityDigitsInNumber, digree = 0; index < countDigitsInTicket; index++, digree++)
            {
                arrayDigits[index] = Convert.ToInt32(stringNumber[digree] - '0');
            }

            return arrayDigits;
        }
        public static int FindNumberDigit(int number)
        {
            int numberDigitInNumber = 0;

            while (number >= 1)
            {
                number /= 10;
                numberDigitInNumber++;
            }

            return numberDigitInNumber;
        }




        

        #region Constructor

        public Ticket(int number, int countDigitsInTicket)
        {
            _numberTicket = CreateArrayWithDigits(number, FindNumberDigit(number), countDigitsInTicket);

        }

        #endregion

    }
}
