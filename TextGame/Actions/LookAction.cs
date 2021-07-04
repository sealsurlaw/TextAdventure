using System;
using System.Collections.Generic;
using TextGame.Helpers;

namespace TextGame.Actions
{
    static class LookAction
    {
        public static void Handle(List<string> keywords, Context context)
        {
            if (keywords.Contains("stats"))
            {
                context.Stats.ViewStats();
                return;
            }

            Console.ForegroundColor = ConsoleColor.White;
            context.Room.LookAt();
        }
    }
}
