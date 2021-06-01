using System;
using System.Collections.Generic;
using TextGame.Helpers;

namespace TextGame.Actions
{
    static class FillAction
    {
        public static void Handle(List<Commands.ItemType> itemTypes, Context context)
        {
            if (context.Room.ContainsItem(Commands.ItemType.Water)
                    && itemTypes.Contains(Commands.ItemType.Waterskin)
                    && context.Backpack.ContainsItem(Commands.ItemType.Waterskin))
            {
                context.Backpack.Get(Commands.ItemType.Waterskin).UseOn(context.Room.GetItem(Commands.ItemType.Water));
            }
            else
            {
                Console.WriteLine("Cannot fill a waterskin.");
            }
        }
    }
}
