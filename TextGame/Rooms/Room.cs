using System;
using System.Collections.Generic;
using TextGame.Helpers;
using TextGame.Items;
using TextGame.Items.InventoryItems;

namespace TextGame.Rooms
{
    abstract class Room
    {
        private readonly Context context;

        public enum TakeReasons
        {
            CannotTake,
            NotHere,
            BackpackFull,
            Success,
        }

        /// <summary>
        /// The scene of the room.
        /// </summary>
        public string Scene { get; }

        public List<Item> ItemsInRoom { get; }

        public Room(string scene, List<Item> itemsInRoom, Context context = null)
        {
            this.context = context;

            Scene = scene;
            ItemsInRoom = itemsInRoom;
        }

        /// <summary>
        /// Look at the room.
        /// </summary>
        public void LookAt()
        {
            PrintHelper.ColorPrint(Scene);
            Console.WriteLine();
        }

        /// <summary>
        /// Look at an item in the room.
        /// </summary>
        /// <param name="itemName">The item name</param>
        public void LookAt(Commands.ItemType ItemType)
        {
            Item item = ItemsInRoom.Find(item => item.ItemType == ItemType);
            if (item == null)
            {
                Console.WriteLine("I don't see that here.");
                return;
            }

            PrintHelper.ColorPrint(item.Description);
        }

        /// <summary>
        /// Take an item from a room.
        /// </summary>
        /// <param name="name">The item name</param>
        /// <returns>Whether the item was taken and the reason if failed</returns>
        public Tuple<bool, TakeReasons> TakeItem(Commands.ItemType ItemType)
        {
            Item item = ItemsInRoom.Find(item => item.ItemType == ItemType);
            if (item == null)
            {
                return new Tuple<bool, TakeReasons>(false, TakeReasons.NotHere);
            }

            if (item.TryGetInventoryItem(out InventoryItem inventoryItem))
            {
                inventoryItem = inventoryItem.Clone();
                inventoryItem.Quantity = 1;
                bool success = context.Backpack.AddItem(inventoryItem.Clone()) && TryRemoveItem(item);
                if (success)
                {
                    return new Tuple<bool, TakeReasons>(true, TakeReasons.Success);
                }

                return new Tuple<bool, TakeReasons>(false, TakeReasons.BackpackFull);
            }

            return new Tuple<bool, TakeReasons>(false, TakeReasons.CannotTake);
        }

        public bool ContainsItem(Commands.ItemType ItemType)
        {
            return ItemsInRoom.Exists(item => item.ItemType == ItemType);
        }

        public Item GetItem(Commands.ItemType ItemType)
        {
            return ItemsInRoom.Find(item => item.ItemType == ItemType);
        }

        private bool TryRemoveItem(Item item, uint quantity = 1)
        {
            // If it's an inventory item (with quantity), handle subtracting from the quantity.
            if (item.TryGetInventoryItem(out InventoryItem inventoryItem))
            {
                if (inventoryItem.Quantity < quantity)
                {
                    return false;
                }

                inventoryItem.Quantity -= quantity;

                if (inventoryItem.Quantity == 0)
                {
                    ItemsInRoom.Remove(item);
                }

                return true;
            }

            // If it's not an inventory item, remove it from the list.
            return ItemsInRoom.Remove(item);
        }
    }
}
