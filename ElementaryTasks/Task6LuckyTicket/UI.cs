using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task6LuckyTicket
{
     static class UI
    {
        public static void ShowMessage(string message)
        {
             Console.WriteLine(message);
        }
        
        public static void ShowInstruction()
        {
            ShowMessage("Вам нужно ввести путь к файлу, в котором первая строка тип билета(Moskow/Piter)," +
                " вторая и третья - начало и конец диапазона билетов(только числа больше 1 и меньше 1000000)");
        }

        public static void ShowCountLuckyTickets(int countLuckyTickets)
        {
            ShowMessage(string.Format("В заданном диапазоне находится {0} счастливых билетов", countLuckyTickets));
        }

    }
}
