using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using NLog;
namespace Task6LuckyTicket
{
    static class Validator
    {
        static public bool IsPathValid(string path)
        {
            return File.Exists(path);
        }

        public static bool IsArgumentsValid(List<string> arguments)
        {
            Logger logger = LogManager.GetCurrentClassLogger();
            bool isFirstArgValid = arguments[0].ToUpper() == "MOSCOW" || arguments[0].ToUpper() == "PITER";
            bool isSecondArgValid = int.TryParse(arguments[1], out int x) && x >= 1;
            bool isThirdArgValid = int.TryParse(arguments[2], out int y) && y >= 1 && x <= y;

            if (isFirstArgValid == false)
            {
                logger.Error("Error occured");
                throw new ArgumentException("Недопустимый тип билета");
            }

            if (isSecondArgValid == false)
            {
                logger.Error("Error occured");
                throw new ArgumentOutOfRangeException("Начало диапазона не подходит. Оно должно быть больше 0 ");
            }

            if (isThirdArgValid == false)
            {
                logger.Error("Error occured");
                throw new ArgumentOutOfRangeException("Конец диапазона не подходит. Он должен быть больше/равен началу и 1\n");
            }

            return isFirstArgValid && isSecondArgValid && isThirdArgValid;
        }
    }
}
