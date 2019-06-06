using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task6LuckyTicket
{
    public static class InputModel
    {
        public static string GetPath(string[] args)
        {
            string _path = string.Empty;
            if (args.Length != 1)
            {
                UI.ShowInstruction();
                _path = GetPath();
            }
            else
            {
                if (Validator.IsPathValid(args[0]))
                {
                    _path = args[0];
                }
                else
                {
                    _path = GetPath();
                }
            }

            return _path;
        }

        public static string GetPath()
        {
            string path = Console.ReadLine();
            bool isPathValid = Validator.IsPathValid(path);

            while (!isPathValid)
            {
                UI.ShowInstruction();
                path = Console.ReadLine();
                isPathValid = File.Exists(path);
            }

            return path;
        }

        public static List<string> ReadFile(string path)
        {
            List<string> arguments = new List<string>(3);
            using (StreamReader strReader = new StreamReader(path))
            {
                arguments.Add(strReader.ReadLine());
                arguments.Add(strReader.ReadLine());
                arguments.Add(strReader.ReadLine());
            }

            return arguments;
        }


    }
}
