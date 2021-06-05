using System;
using System.Collections.Generic;
using TextGame.Items;
using TextGame.Items.InventoryItems;

namespace TextGame.Actions
{
    static class UseAction
    {
        public static void Handle(List<string> keywords, Context context)
        {
            if (context.Backpack.ContainsItem(keywords[0]))
            {
                Tuple<Item, float> inventoryItem = context.Backpack.GetMostLikelyMatch(keywords);
                Tuple<Item, float> item = context.Room.GetMostLikelyMatch(keywords);

                (inventoryItem.Item1 as InventoryItem).UseOn(item.Item1);
            }
        }
    }
}
