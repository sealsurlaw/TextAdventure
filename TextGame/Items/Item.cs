using TextGame.Helpers;
using TextGame.Items.InventoryItems;

namespace TextGame.Items
{
    abstract class Item
    {
        /// <summary>
        /// The item's name.
        /// </summary>
        public string Name { get; }

        /// <summary>
        /// The item's description.
        /// </summary>
        public string Description { get; }

        /// <summary>
        /// Whether the item is an inventory type.
        /// </summary>
        public bool IsInventoryItem { get; }

        protected Item(string name, string description, bool isInventoryItem)
        {
            Name = name;
            Description = description;
            IsInventoryItem = isInventoryItem;
        }

        /// <summary>
        /// Trys to get an inventory object.
        /// </summary>
        /// <param name="inventoryItem">The inventory item</param>
        /// <returns>Whether the inventory item was found</returns>
        public bool TryGetInventoryItem(out InventoryItem inventoryItem)
        {
            inventoryItem = null;

            if (IsInventoryItem)
            {
                inventoryItem = this as InventoryItem;
                return true;
            }

            return false;
        }

        /// <summary>
        /// Makes the name plural.
        /// </summary>
        /// <returns>The plural of the name</returns>
        public virtual string Pluralize()
        {
            return Name + "s";
        }

        /// <summary>
        /// Looks at this inventory item.
        /// </summary>
        /// <returns>The description of the item</returns>
        public virtual string LookAt()
        {
            return Description;
        }

        public virtual string Drink()
        {
            return "You can't drink that.";
        }
    }
}
