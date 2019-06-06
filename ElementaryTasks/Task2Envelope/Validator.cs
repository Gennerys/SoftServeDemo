using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NLog;

namespace Task2Envelope
{
    public  static class Validator
    {
        public static bool Input(string first, string second,string third,string forth, out double [] mas)
        {
            Logger logger = LogManager.GetCurrentClassLogger();
            mas = new double[4];
            bool isFirstEnvelopeHeightChecked = double.TryParse(first, out mas[0]);
            bool isFirstEnvelopeWidthChecked = double.TryParse(second, out mas[1]);
            bool isSecondEnvelopeHeightChecked = double.TryParse(third, out mas[2]);
            bool isSecondEnvelopeWidthChecked = double.TryParse(forth, out mas[3]);

            if (isFirstEnvelopeHeightChecked && isFirstEnvelopeWidthChecked &&
                isSecondEnvelopeHeightChecked && isSecondEnvelopeWidthChecked &&
                mas[0] > 0.0 && mas[1] > 0.0 &&
                mas[2] > 0.0 && mas[3] > 0.0)
            {
                logger.Info("Validation completed");
                return true;
            }
            else
            {
                logger.Error("Uncorrect input");
                return false;
            }

        }




    }
}
