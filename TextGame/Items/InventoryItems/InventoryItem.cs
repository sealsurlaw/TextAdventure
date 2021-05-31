﻿using TextGame.Helpers;

namespace TextGame.Items.InventoryItems
{
    /// <summary>
    /// An item in the player's inventory.
    /// </summary>
    abstract class InventoryItem : Item
    {
                /// <summary>
        /// A unique item number.
        /// </summary>
        public uint ItemNumber { get; }

        /// <summary>
        /// The item's weight in lbs.
        /// </summary>
        public decimal Weight { get; }

        /// <summary>
        /// The number of this item.
        /// </summary>
        public uint Quantity { get; set; }

        protected InventoryItem(string name, string description, Commands.ObjectType objectType, uint itemNumber, decimal weight, uint quantity)
            : base(name, description, objectType, true)
        {
            ItemNumber = itemNumber;
            Weight = weight;
            Quantity = quantity;
        }

        /// <summary>
        /// Makes the name plural.
        /// </summary>
        /// <returns>The plural of the name</returns>
        public override string Pluralize()
        {
            if (Quantity == 1)
            {
                return Name;
            }

            return Name + "s";
        }

        /// <summary>
        /// Use this inventory item on another.
        /// </summary>
        /// <param name="inventoryItem">The other inventory item</param>
        abstract public void UseOn(InventoryItem inventoryItem);

        /// <summary>
        /// Clones the inventory item.
        /// </summary>
        /// <returns>The cloned inventory item</returns>
        abstract public InventoryItem Clone();
    }
}