using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task4FileParser
{
    class StringReplacer : IModeParser
    {
        public void ParseAlgortithm(string [] args)
        {
           
            ReplaceString(args[0], args[1], args[2]);

        }
        
        public static void ReplaceString(string path, string stringToReplace,string stringForReplace)
        {
            if (Validator.Validate(path))
            {
                bool isThereStringToReplace = false;

                string text = string.Empty;
                using (StreamReader streamReader = new StreamReader(path))
                {
                    while ((text = streamReader.ReadLine()) != null)
                    {
                        if (text.Equals(stringToReplace))
                        {
                            isThereStringToReplace = true;
                            break;
                        }
                        
                    }
                    if(!isThereStringToReplace)
                    {
                        throw new IOException("Нет искомой строки");
                    }
                }
               
                if (isThereStringToReplace)
                {
                    text = File.ReadAllText(path);
                    text = text.Replace(stringToReplace, stringForReplace);
                    File.WriteAllText("AfterReplace.txt", text);
                }
            }
            else
            {
                throw new FileNotFoundException("Указан неверный путь, либо некорректно!");
            }
        }

    }
}
