using System;
using TextGame.Helpers;

namespace TextGame.Items.InventoryItems
{
    class Sword : InventoryItem
    {
        public static readonly string NAME = "Sword";

        public static readonly string DESCRIPTION = "A dull, slightly rusted short sword about 2 feet long.";

        public static readonly Commands.ItemType OBJECT_TYPE = Commands.ItemType.Null;

        public static readonly InvetoryItemNumbers ITEM_NUMBER = InvetoryItemNumbers.Sword;

        public static readonly decimal WEIGHT = 2.5m;

        public Sword()
            : this(1) { }

        public Sword(uint quantity)
            : base(NAME, DESCRIPTION, OBJECT_TYPE, ITEM_NUMBER, WEIGHT, quantity) { }

        public override void UseOn(Item item)
        {
            throw new NotImplementedException();
        }

        public override InventoryItem Clone()
        {
            return new Sword(Quantity);
        }
    }
}
