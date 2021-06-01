using System;
using System.Collections.Generic;
using TextGame.Helpers;

namespace TextGame.Actions
{
    static class LookAtAction
    {
        public static void Handle(List<Commands.ItemType> itemTypes, Context context)
        {
            if (itemTypes.Count > 0 && context.Room.ContainsItem(itemTypes[0]))
            {
                context.Room.LookAt(itemTypes[0]);
            }
            else if (itemTypes.Count > 0 && context.Backpack.ContainsItem(itemTypes[0]))
            {
                context.Backpack.LookAt(itemTypes[0]);
            }
            else
            {
                Console.WriteLine("I don't see that here.");
            }
        }
    }
}
