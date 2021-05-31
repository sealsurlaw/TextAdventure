using System;
using TextGame.Helpers;

namespace TextGame.Items.InventoryItems
{
    class CopperCoin : InventoryItem
    {
        public static readonly string NAME = "Copper Coin";

        public static readonly string DESCRIPTION = "A copper coin. It's about half an inch in diameter. Most merchants would be happy to accept this.";

        public static readonly Commands.ObjectType OBJECT_TYPE = Commands.ObjectType.Coin;

        public static readonly uint ITEM_NUMBER = 4;

        public static readonly decimal WEIGHT = 0m;

        public CopperCoin()
            : this(1) { }

        public CopperCoin(uint quantity)
            : base(NAME, DESCRIPTION, OBJECT_TYPE, ITEM_NUMBER, WEIGHT, quantity) { }

        public override void UseOn(InventoryItem inventoryItem)
        {
            throw new NotImplementedException();
        }

        public override InventoryItem Clone()
        {
            return new CopperCoin(Quantity);
        }
    }
}
