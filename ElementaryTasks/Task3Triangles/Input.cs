using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task3Triangles
{
//    Формат ввода(разделитель - запятая): 
//<имя>, <длина стороны>, <длина стороны>, <длина стороны>
//•	Ввод должен быть нечувствителен к регистру, пробелам, табам.
//•	Вывод данных должен быть следующем примере:
//============= Triangles list: ===============
//1. [Triangle first]: 17.23 сm
//2. [Triangle 22]: 13 cm
//3. [Triangle 1]: 1.5 cm

    class Input
    {
        public static void InputTriangles()
        {
            string readInput = Console.ReadLine();
            string[] inputArgs;
            if (!readInput.Contains(','))
            {
                throw new ArgumentException("Ввод необходимо осуществлять через , ");
            }
            else
            {
                inputArgs = readInput.Split(',');
                string triangleName = inputArgs[0].ToUpper();
                double[] sides = new double[] { Convert.ToDouble(inputArgs[1]), Convert.ToDouble(inputArgs[2]), Convert.ToDouble(inputArgs[3]) };

            }

        }
    }
}
