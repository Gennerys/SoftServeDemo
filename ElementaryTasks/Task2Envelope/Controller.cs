using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task2Envelope
{
    static class Controller
    {
       // public static bool isWorking = true;

        public static void ConfirmValidation()
        {
            UI.ShowMessage("Введите высоту и ширину конвертов: ");
            bool isValidationCompleted = Validator.Input(UI.InputFromConsole(), UI.InputFromConsole(), UI.InputFromConsole(), UI.InputFromConsole(), out double[] mas);

            if (isValidationCompleted)
            {
                Envelope firstEnvelope = new Envelope(mas[0], mas[1]);
                Envelope secondEnvelope = new Envelope(mas[2], mas[3]);
                EnvelopeComparer<Envelope> EnvelopeComparer = new EnvelopeComparer<Envelope>();
                if (EnvelopeComparer.Compare(firstEnvelope, secondEnvelope) == 1)
                {
                    UI.ShowMessage("Первый конверт можно вложить");
                }
                else if (EnvelopeComparer.Compare(firstEnvelope, secondEnvelope) == -1)
                {
                    UI.ShowMessage("Первый конверт нельзя вложить");
                }
                else
                {
                    UI.ShowMessage("Конверты равны");
                }
               
            }
            else
            {
                UI.ShowMessage("Недопустимый ввод, введите пожалуйста целые/дробные числа > 0");
                
            }
        }

        public static bool ContinueWork()
        {
            UI.ShowMessage("Вы хотите продолжить работу?Ответьте y/yes");
            string answer = Console.ReadLine();
            if (answer.ToLower() == "y" || answer.ToLower() == "yes")
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
