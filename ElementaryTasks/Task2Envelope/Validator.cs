using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task2Envelope
{
    public  static class Validator
    {


        public static bool InputValidation(ref double firstEnvelopeHeight, ref double firstEnvelopeWidth, ref double secondEnvelopeHeight, ref double secondEnvelopeWidth)
        {
            Console.WriteLine("Введите параметры конвертов");

            bool isFirstEnvelopeHeightChecked = double.TryParse(Console.ReadLine(), out firstEnvelopeHeight);
            bool isFirstEnvelopeWidthChecked = double.TryParse(Console.ReadLine(), out firstEnvelopeWidth);
            bool isSecondEnvelopeHeightChecked = double.TryParse(Console.ReadLine(), out secondEnvelopeHeight);
            bool isSecondEnvelopeWidthChecked = double.TryParse(Console.ReadLine(), out secondEnvelopeWidth);

            if (isFirstEnvelopeHeightChecked && isFirstEnvelopeWidthChecked &&
                isSecondEnvelopeHeightChecked && isSecondEnvelopeWidthChecked &&
                firstEnvelopeHeight > 0.0 && firstEnvelopeWidth > 0.0 &&
                secondEnvelopeHeight > 0.0 && secondEnvelopeWidth > 0.0)
            { return true; }
            else
            {
                 //throw new FormatException("Недопустимый ввод, введите пожалуйста целые/дробные числа"); 
                return false;

            }


        }

    }
}
