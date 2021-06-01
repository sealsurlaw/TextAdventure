using System;
using System.Collections.Generic;
using TextGame.Helpers;

namespace TextGame.Actions
{
    static class LookAction
    {
        public static void Handle(List<Commands.ItemType> itemTypes, Context context)
        {
            Console.ForegroundColor = ConsoleColor.White;
            context.Room.LookAt();
        }
    }
}
