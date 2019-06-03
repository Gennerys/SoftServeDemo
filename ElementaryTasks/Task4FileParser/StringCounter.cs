using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task4FileParser
{
    public  class StringCounter:IModeParser
    {
        public void ParseAlgortithm(string [] args)
        {
            int answer = StringsCount(args[0], args[1]);
            Console.WriteLine(answer); 
        }

        public static int StringsCount(string path, string stringToCount)
        {
            if (Validator.Validate(path))
            {
                bool isThereStringToCount = false;
                int stringCounter = 0;

                string text = string.Empty;
                using (StreamReader streamReader = new StreamReader(path))
                {
                    while ((text = streamReader.ReadLine()) != null)
                    {
                        if (text.Contains(stringToCount))
                        {
                            isThereStringToCount = true;
                            stringCounter++;
                        }

                    }
                    if (!isThereStringToCount)
                    {
                        throw new IOException("Нет искомой строки");
                    }
                }
                return stringCounter;
            }
            else
            {
                throw new FileNotFoundException("Указан неверный путь, либо некорректно!");
            }
        }

        public static int Search(string pat, string txt)
        {
            int M = pat.Length;
            int N = txt.Length;
            int i = 0;
            int counter = 0;
            while (i <= N - M)
            {
                int j;

                /* For current index i, check for pattern match */
                for (j = 0; j < M; j++)
                    if (txt[i + j] != pat[j])
                        break;

                if (j == M) // if pat[0...M-1] = txt[i, i+1, ...i+M-1]  
                {
                   
                    counter++;
                    i = i + M;
                }
                else if (j == 0)
                    i = i + 1;
                else
                    i = i + j; // slide the pattern by j  
            }
            return counter;
        }
    }
}
