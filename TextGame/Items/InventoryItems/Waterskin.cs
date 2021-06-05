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

        private enum FillLevel
        {
            Full,
            Half,
            Empty
        }

        private FillLevel WaterLevel;

        public Waterskin()
            : this(1) { }

        public Waterskin(uint quantity)
            : base(NAME, DESCRIPTION, ITEM_NUMBER, WEIGHT, quantity)
        {
            WaterLevel = FillLevel.Full;
        }

        public override void UseOn(Item item)
        {
            // TODO
        }

        public override string Drink()
        {
            switch(WaterLevel)
            {
                case FillLevel.Full:
                    WaterLevel = FillLevel.Half;
                    return "You take a sip from your waterskin.";
                case FillLevel.Half:
                    WaterLevel = FillLevel.Empty;
                    return "You drink the last drops of your waterskin.";
                case FillLevel.Empty:
                    return "There is nothing to drink. Your waterskin is empty.";
            }

            return string.Empty;
        }

        public override InventoryItem Clone()
        {
            return new Waterskin(Quantity);
        }
    }
}
