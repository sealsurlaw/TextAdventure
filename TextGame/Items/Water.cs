using TextGame.Helpers;

namespace TextGame.Items
{
    class Water : Item
    {
        public static readonly string NAME = "Water";

        public static readonly string DESCRIPTION = "Cool clean water. I can [FILL] a container with this.";

        public Water()
            : base(NAME, DESCRIPTION, false) { }
    }
}
