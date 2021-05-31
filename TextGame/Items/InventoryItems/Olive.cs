using System;
using TextGame.Helpers;

namespace TextGame.Items.InventoryItems
{
    class Olive : InventoryItem
    {
        public static readonly string NAME = "Olive";

        public static readonly string DESCRIPTION = "A ripe olive.";

        public static readonly Commands.ObjectType OBJECT_TYPE = Commands.ObjectType.Olive;

        public static readonly uint ITEM_NUMBER = 3;

        public static readonly decimal WEIGHT = 0.1m;

        public Olive()
            : this(1) { }

        public Olive(uint quantity)
            : base(NAME, DESCRIPTION, OBJECT_TYPE, ITEM_NUMBER, WEIGHT, quantity) { }

        public override void UseOn(InventoryItem inventoryItem)
        {
            throw new NotImplementedException();
        }

        public override InventoryItem Clone()
        {
            return new Olive(Quantity);
        }
    }
}
