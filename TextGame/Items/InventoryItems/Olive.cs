using System;
using TextGame.Helpers;

namespace TextGame.Items.InventoryItems
{
    class Olive : InventoryItem
    {
        public static readonly string NAME = "Olive";

        public static readonly string DESCRIPTION = "A ripe olive.";

        public static readonly InvetoryItemNumbers ITEM_NUMBER = InvetoryItemNumbers.Olive;

        public static readonly decimal WEIGHT = 0.1m;

        public Olive()
            : this(1) { }

        public Olive(uint quantity)
            : base(NAME, DESCRIPTION, ITEM_NUMBER, WEIGHT, quantity) { }

        public override void UseOn(Item item)
        {
            throw new NotImplementedException();
        }

        public override InventoryItem Clone()
        {
            return new Olive(Quantity);
        }
    }
}
