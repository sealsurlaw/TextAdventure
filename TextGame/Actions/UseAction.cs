using System.Collections.Generic;
using TextGame.Helpers;
using TextGame.Items;
using TextGame.Items.InventoryItems;

namespace TextGame.Actions
{
    static class UseAction
    {
        public static void Handle(List<Commands.ItemType> itemTypes, Context context)
        {
            if (context.Backpack.ContainsItem(itemTypes[0]))
            {
                InventoryItem inventoryItem = context.Backpack.Get(itemTypes[0]);
                Item item = context.Room.GetItem(itemTypes[1]);

                inventoryItem.UseOn(item);
            }
        }
    }
}
