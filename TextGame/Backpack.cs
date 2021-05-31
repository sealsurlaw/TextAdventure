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
        public Dictionary<uint, InventoryItem> Contents { get; }

        private Stats stats;

        public Backpack(Stats stats = null)
        {
            TotalWeight = 0;
            Contents = new Dictionary<uint, InventoryItem>();
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
            foreach (InventoryItem inventoryItem in Contents.Values)
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

            if (Contents.ContainsKey(inventoryItem.ItemNumber))
            {
                Contents[inventoryItem.ItemNumber].Quantity += inventoryItem.Quantity;
            }
            else
            {
                Contents.Add(inventoryItem.ItemNumber, inventoryItem);
            }

            TotalWeight += itemTotalWeight;

            return true;
        }

        public bool RemoveItem(uint itemNumber, uint quantity)
        {
            if (Contents.TryGetValue(itemNumber, out InventoryItem inventoryItem))
            {
                if (inventoryItem.Quantity < quantity)
                {
                    return false;
                }

                inventoryItem.Quantity -= quantity;
                TotalWeight -= quantity * inventoryItem.Weight;

                if (inventoryItem.Quantity == 0)
                {
                    Contents.Remove(itemNumber);
                }

                return true;
            }

            return false;
        }

        public bool ContainsItem(Commands.ObjectType objectType)
        {
            foreach (InventoryItem inventoryItem in Contents.Values)
            {
                if (inventoryItem.ObjectType == objectType)
                {
                    return true;
                }
            }

            return false;
        }

        /// <summary>
        /// Look at an item in the room.
        /// </summary>
        /// <param name="itemName">The item name</param>
        public void LookAt(Commands.ObjectType objectType)
        {
            InventoryItem inventoryItem = null;
            foreach (InventoryItem ii in Contents.Values)
            {
                if (ii.ObjectType == objectType)
                {
                    inventoryItem = ii;
                    break;
                }
            }

            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.Write("[Backpack] ");
            Console.ResetColor();
            PrintHelper.ColorPrint(inventoryItem.Description);
        }
    }
}
