using TextGame.Helpers;

namespace TextGame.Items
{
    class Fountain : Item
    {
        public static readonly string NAME = "Fountain";

        public static readonly string DESCRIPTION = "A fountain overflowing with cool fresh water fed from an underground spring. You can see a {COIN} sparkling from beneath the clear {WATER}.";

        public static readonly Commands.ObjectType OBJECT_TYPE = Commands.ObjectType.Fountain;

        public Fountain()
            : base(NAME, DESCRIPTION, OBJECT_TYPE, false) { }
    }
}
