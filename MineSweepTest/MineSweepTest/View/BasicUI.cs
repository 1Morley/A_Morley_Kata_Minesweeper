using MineSweepTest.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MineSweepTest.View
{
    internal static class BasicUI
    {

        public static int getIndexFromList(string[] optionList, bool exitOption) 
        {
            StringBuilder bob = new StringBuilder();
            bob.Append("Pick option:");
            for (int i = 0; i < optionList.Length; i++)
            {
                bob.Append(ListOptionToString(optionList[i], (i+1)));
            }
            if (exitOption) 
            {
                bob.Append(ListOptionToString("exit", 0));
            }
            return getInt(bob.ToString(), 0, optionList.Length);
        }

        private static string ListOptionToString(string optionString, int index)
        {
            optionString = optionString.ToLower();
            optionString = char.ToUpper(optionString[0]) + optionString.Substring(1);
            return $"\n{index}. {optionString}";
        }
        public static int getInt(string message, int min, int max) 
        {
            int result;

            do {
                if (int.TryParse(getString(message), out result))
                {
                    if (result >= min && result <= max)
                    {
                        break;
                    }
                    else
                    {
                        Console.WriteLine($"INPUT MUST BE AN INPUT FROM {min} TO {max}\n\n");
                    }
                }
                else 
                {
                    Console.WriteLine($"INVALID INPUT\n\n");
                }

            } while (true);

            return result;
        }

        public static string getString(string question)
        {
            string userInput = string.Empty;
            while (string.IsNullOrWhiteSpace(userInput))
            {
                Console.WriteLine(question);
                userInput = Console.ReadLine();
            }
                return userInput;
        }

    }
}
