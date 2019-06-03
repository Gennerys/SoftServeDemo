using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task2Envelope
{
  

    public static class UI
    {
        public static bool isWorking = true;
        public static bool GetAnswer()
        {
            double firstEnvelopeHeight = 0.0;
            double firstEnvelopeWidth = 0.0;
            double secondEnvelopeHeight = 0.0;
            double secondEnvelopeWidth = 0.0;
            bool isValidationCompleted = Validator.InputValidation(ref firstEnvelopeHeight, ref firstEnvelopeWidth, ref secondEnvelopeHeight, ref secondEnvelopeWidth);

            if (isValidationCompleted)
            {
               // bool isWorking = true;

               // while (isWorking)
               // {
                    Envelope envelope1 = new Envelope(firstEnvelopeHeight, firstEnvelopeWidth);
                    Envelope envelope2 = new Envelope(secondEnvelopeHeight, secondEnvelopeWidth);
                    EnvelopeComparer<Envelope> abc = new EnvelopeComparer<Envelope>();
                    if (abc.Compare(envelope1, envelope2) == 1)
                    {
                        Console.WriteLine("Первый конверт можно вложить");
                    }
                    else if (abc.Compare(envelope1, envelope2) == -1)
                    {
                        Console.WriteLine("Первый конверт нельзя вложить");
                    }
                    else
                    {
                        Console.WriteLine("Конверты равны");
                    }
                      return true;
                    //Console.WriteLine("Вы хотите продолжить работу?Ответьте y/yes");
                    //string answer = Console.ReadLine();
                    //if (answer.ToLower() == "y" || answer.ToLower() == "yes")
                    //{
                    //    Validator.InputValidation(ref firstEnvelopeHeight, ref firstEnvelopeWidth, ref secondEnvelopeHeight, ref secondEnvelopeWidth);
                    //}
                   // else { isWorking = false; }
                //}
            }
            else
            {
                //Validator.InputValidation(ref firstEnvelopeHeight, ref firstEnvelopeWidth, ref secondEnvelopeHeight, ref secondEnvelopeWidth);
                Console.WriteLine("Недопустимый ввод, введите пожалуйста целые/дробные числа > 0");
                return false;
            }
          
        }
        public static void CheckResults()
        {
            Console.WriteLine("Вы хотите продолжить работу?Ответьте y/yes");
            string answer = Console.ReadLine();
            if (answer.ToLower() == "y" || answer.ToLower() == "yes")
            {
                UI.GetAnswer();
            }
            else { UI.isWorking = false; }
        }
    }
}
