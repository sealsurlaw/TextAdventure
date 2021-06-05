using TextGame.Helpers;

namespace TextGame.Items
{
    class Fountain : Item
    {
        public static readonly string NAME = "Fountain";

        public static readonly string DESCRIPTION = "A fountain overflowing with cool fresh water fed from an underground spring. You can see a {COIN} sparkling from beneath the clear {WATER}.";

        public Fountain()
            : base(NAME, DESCRIPTION, false) { }
    }
}
