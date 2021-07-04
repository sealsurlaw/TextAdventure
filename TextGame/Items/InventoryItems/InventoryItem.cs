using TextGame.Helpers;

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
        public InvetoryItemNumbers ItemNumber { get; }

        /// <summary>
        /// The item's weight in lbs.
        /// </summary>
        public decimal Weight { get; }

        /// <summary>
        /// The number of this item.
        /// </summary>
        public uint Quantity { get; set; }

        protected InventoryItem(string name, string description, InvetoryItemNumbers itemNumber, decimal weight, uint quantity, Context context = null)
            : base(name, description, true, context)
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
        /// Use this inventory item on another item.
        /// </summary>
        /// <param name="item">The other item</param>
        abstract public void UseOn(Item item);

        /// <summary>
        /// Clones the inventory item.
        /// </summary>
        /// <returns>The cloned inventory item</returns>
        abstract public InventoryItem Clone();
    }
}
