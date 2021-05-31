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

        public Commands.ObjectType ObjectType { get; }

        public bool IsInventoryItem { get; }

        protected Item(string name, string description, Commands.ObjectType objectType, bool isInventoryItem)
        {
            Name = name;
            Description = description;
            ObjectType = objectType;
            IsInventoryItem = isInventoryItem;
        }

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
    }
}
