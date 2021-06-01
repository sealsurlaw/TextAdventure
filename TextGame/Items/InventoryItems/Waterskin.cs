using System;
using TextGame.Helpers;

namespace TextGame.Items.InventoryItems
{
    class Waterskin : InventoryItem
    {
        public static readonly string NAME = "Waterskin";

        public static readonly string DESCRIPTION = "A drinking container made from leather.";

        public static readonly Commands.ItemType OBJECT_TYPE = Commands.ItemType.Waterskin;

        public static readonly uint ITEM_NUMBER = 5;

        public static readonly decimal WEIGHT = 0.5m;

        public Waterskin()
            : this(1) { }

        public Waterskin(uint quantity)
            : base(NAME, DESCRIPTION, OBJECT_TYPE, ITEM_NUMBER, WEIGHT, quantity) { }

        public override void UseOn(Item item)
        {
            if (item.ItemType == Commands.ItemType.Water)
            {
                Console.WriteLine("You fill your waterskin with water.");
            }
        }

        public override InventoryItem Clone()
        {
            return new Waterskin(Quantity);
        }
    }
}
