using System;
using TextGame.Helpers;

namespace TextGame.Items.InventoryItems
{
    class Cactus : InventoryItem
    {
        public static readonly string NAME = "Cactus";

        public static readonly string DESCRIPTION = "A prickly cactus.";

        public static readonly Commands.ObjectType OBJECT_TYPE = Commands.ObjectType.Null;

        public static readonly uint ITEM_NUMBER = 2;

        public static readonly decimal WEIGHT = 0.8m;

        public Cactus()
            : this(1) { }

        public Cactus(uint quantity)
            : base(NAME, DESCRIPTION, OBJECT_TYPE, ITEM_NUMBER, WEIGHT, quantity) { }

    public override string Pluralize()
        {
            if (Quantity == 1)
            {
                return Name;
            }

            return "Cacti";
        }

        public override void UseOn(InventoryItem inventoryItem)
        {
            throw new NotImplementedException();
        }

        public override InventoryItem Clone()
        {
            return new Cactus(Quantity);
        }
    }
}
