using System;
using System.Collections.Generic;
using TextGame.Helpers;
using TextGame.Items.InventoryItems;

namespace TextGame
{
    class Backpack
    {
        /// <summary>
        /// The maximum weight that can be carried in this backpack.
        /// </summary>
        public decimal MaxWeight {
            get
            {
                return stats.GetStat(Stats.StatType.Strength) * 2.5m;
            }
        }

        /// <summary>
        /// The current total weight in this backpack.
        /// </summary>
        public decimal TotalWeight { get; private set; }

        /// <summary>
        /// The contents of the backpack.
        /// </summary>
        public List<InventoryItem> Contents { get; }

        private readonly Stats stats;

        public Backpack(Stats stats = null)
        {
            Contents = new List<InventoryItem>()
            {
                new Waterskin(),
            };

            TotalWeight = 0;
            foreach (InventoryItem item in Contents)
            {
                TotalWeight += item.Quantity * item.Weight;
            }

            this.stats = stats;
        }

        /// <summary>
        /// Views the contents of your backpack.
        /// </summary>
        public void ViewContents()
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine($"Your backpack ({TotalWeight} lbs / {MaxWeight} lbs) contains the following:");
            Console.ForegroundColor = ConsoleColor.Cyan;
            foreach (InventoryItem inventoryItem in Contents)
            {
                string itemString = string.Format("{0, -15}", inventoryItem.Pluralize());
                Console.WriteLine($"\t{inventoryItem.Quantity}\t{itemString}\t{inventoryItem.Quantity * inventoryItem.Weight} lbs");
            }

            Console.ResetColor();
        }

        /// <summary>
        /// Add an item to your backpack.
        /// </summary>
        /// <param name="inventoryItem">The inventory item to add</param>
        /// <returns>Whether the inventory item was successfully added</returns>
        public bool AddItem(InventoryItem inventoryItem)
        {
            decimal itemTotalWeight = inventoryItem.Quantity * inventoryItem.Weight;
            if (TotalWeight + itemTotalWeight > MaxWeight)
            {
                return false;
            }

            if (Contents.Exists(item => item.ItemNumber == inventoryItem.ItemNumber))
            {
                Contents.Find(item => item.ItemNumber == inventoryItem.ItemNumber).Quantity += inventoryItem.Quantity;
            }
            else
            {
                Contents.Add(inventoryItem);
            }

            TotalWeight += itemTotalWeight;

            return true;
        }

        public bool RemoveItem(InvetoryItemNumbers itemNumber, uint quantity)
        {
            if (Contents.Exists(item => item.ItemNumber == itemNumber))
            {
                InventoryItem inventoryItem = Contents.Find(item => item.ItemNumber == itemNumber);
                if (inventoryItem.Quantity < quantity)
                {
                    return false;
                }

                inventoryItem.Quantity -= quantity;
                TotalWeight -= quantity * inventoryItem.Weight;

                if (inventoryItem.Quantity == 0)
                {
                    Contents.Remove(inventoryItem);
                }

                return true;
            }

            return false;
        }

        /// <summary>
        /// Checks if your backpack contains an object.
        /// </summary>
        /// <param name="ItemType">The object type.</param>
        /// <returns>Whether the backpack contains the object type</returns>
        public bool ContainsItem(Commands.ItemType ItemType)
        {
            return Contents.Exists(item => item.ItemType == ItemType);
        }

        /// <summary>
        /// Look at an item in the room.
        /// </summary>
        /// <param name="itemName">The item name</param>
        public void LookAt(Commands.ItemType ItemType)
        {
            InventoryItem inventoryItem = Contents.Find(item => item.ItemType == ItemType);

            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.Write("[Backpack] ");
            Console.ResetColor();
            PrintHelper.ColorPrint(inventoryItem.Description);
        }

        /// <summary>
        /// Gets an item from your backpack.
        /// </summary>
        /// <param name="ItemType">The object type</param>
        /// <returns>The inventory item</returns>
        public InventoryItem Get(Commands.ItemType ItemType)
        {
            return Contents.Find(item => item.ItemType == ItemType);
        }
    }
}
