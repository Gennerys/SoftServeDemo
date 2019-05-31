using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task5NumberConverter
{
    class SumCapital
    {
        //Записывает пропись суммы строчными буквами.

        public static StringBuilder GetCapital(decimal sum, StringBuilder result)
        {
            decimal integerPart = Math.Floor(sum);
            uint fractionalPart = (uint)((sum - integerPart) * 100);

            //Число.Пропись(целая, валюта.ОсновнаяЕдиница, result);
            //return ДобавитьКопейки(дробная, валюта, result);
        }

        //Записывает пропись суммы строчными буквами (для дробных)
        public static StringBuilder CapitalNumber(double sum, StringBuilder result)
        {
            double integerPart = Math.Floor(sum);
            //Вынесение 100 за скобки позволяет избежать ошибки округления
            uint fractionalPart = (uint)(sum * 100) - (uint)(integerPart * 100);
            //Число.Пропись(целая, валюта.ОсновнаяЕдиница, result);
            //return ДобавитьКопейки(дробная, валюта, result);
        }


        //private static StringBuilder ДобавитьКопейки(uint дробная, Валюта валюта, StringBuilder result)
        //{
        //    result.Append(' ');

        //    // Эта строчка выполняется быстрее, чем следующая за ней закомментированная.
        //    result.Append(дробная.ToString("00"));
        //    //result.AppendFormat ("{0:00}", дробная);

        //    result.Append(' ');
        //    result.Append(Число.Согласовать(валюта.ДробнаяЕдиница, дробная));

        //    return result;
        //}

        public static string CheckSum(decimal sum)
        {
            if (sum < 0) { return "Сумма должна быть неотрицательной."};

            decimal integerPart = Math.Floor(sum);
            decimal fractionalPart = (sum - integerPart) * 100;
            
            if(Math.Floor(fractionalPart)!= fractionalPart)
            {
                return "Сумма должна содержать не более 2 цифр после запятой.";
            }
            return null;
        }

        //Возвращает пропись заданной суммы

        public static string LowerCase(decimal n)
        {
           // return Число.ApplyCaps(LowerCase(n, new StringBuilder()), Заглавные.Нет);
        }
       
        // Возвращает пропись заданной суммы строчными буквами.
     
        public static string LowerCase(double n)
        {
           // return Число.ApplyCaps(Пропись(n, new StringBuilder()), Заглавные.Нет);
        }


        // Возвращает пропись заданной суммы.

        public static string LowerCase(double n, CapitalLetters заглавные)
        {
            return Число.ApplyCaps(LowerCase(n, new StringBuilder()), заглавные);
        }




    }
}
