using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace test
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                double  t = 2351656;

                //выводим сумму в рублях
                Console.WriteLine("{0} р. = {1}", t, RusCurrency.Str(t));

                //выводим ее же в валюте "USD"
                Console.WriteLine("${0} = {1}", t, RusCurrency.Str(t, "USD"));

                //регистрируем новую валюту - британский фунт стерлингов (GBP)
                RusCurrency.Register("GBP", true, "фунт", "фунта", "фунтов", "пенс", "пенса", "пенсов");
                Console.WriteLine("#{0} = {1}", t, RusCurrency.Str(t, "GBP"));

                //пытаемся вызвать незарегистрированную валюту - казахские тенге
                Console.WriteLine("{0} = {1}", t, RusCurrency.Str(t, "KZT"));
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}
