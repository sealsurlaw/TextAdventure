using System;
using TextGame.Helpers;

namespace TextGame.Items.InventoryItems
{
    class Waterskin : InventoryItem
    {
        public static readonly string NAME = "Waterskin";

        public static readonly string DESCRIPTION = "A drinking container made from leather.";

        public static readonly InvetoryItemNumbers ITEM_NUMBER = InvetoryItemNumbers.Waterskin;

        public static readonly decimal WEIGHT = 0.5m;

        public Waterskin()
            : this(1) { }

        public Waterskin(uint quantity)
            : base(NAME, DESCRIPTION, ITEM_NUMBER, WEIGHT, quantity) { }

        public override void UseOn(Item item)
        {
            // TODO
        }

        public override InventoryItem Clone()
        {
            return new Waterskin(Quantity);
        }
    }
}
