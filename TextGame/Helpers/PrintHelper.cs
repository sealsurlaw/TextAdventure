using System;
using System.Collections.Generic;

namespace TextGame.Helpers
{
    static class PrintHelper
    {
        private static readonly ConsoleColor itemColor = ConsoleColor.Cyan;
        private static readonly ConsoleColor actionColor = ConsoleColor.Green;

        public static void ColorPrint(string s)
        {
            s = SplitString(s);
            
            foreach (char c in s)
            {
                if (c == '{')
                {
                    Console.ForegroundColor = itemColor;
                }

                if (c == '[')
                {
                    Console.ForegroundColor = actionColor;
                }

                Console.Write(c);

                if (c == '}')
                {
                    Console.ForegroundColor = ConsoleColor.Gray;
                }

                if (c == ']')
                {
                    Console.ForegroundColor = ConsoleColor.Gray;
                }
            }
        }

        private static string SplitString(string s)
        {
            string splitString = string.Empty;
            string head;
            string tail = s;
            do
            {
                Tuple<string, string> headTail = SplitLines(tail);
                head = headTail.Item1;
                tail = headTail.Item2;

                splitString += head + '\n';
            } while (tail != null);

            return splitString;
        }

        private static Tuple<string, string> SplitLines(string s)
        {
            if (s.Length < Console.WindowWidth)
            {
                return new Tuple<string, string>(s, null);
            }

            int lastSpace = s.Substring(0, Console.WindowWidth).LastIndexOf(' ');
            return new Tuple<string, string>(s.Substring(0, lastSpace), s.Substring(lastSpace + 1));
        }
    }
}
