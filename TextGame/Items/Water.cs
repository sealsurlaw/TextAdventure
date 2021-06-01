using TextGame.Helpers;

namespace TextGame.Items
{
    class Water : Item
    {
        public static readonly string NAME = "Water";

        public static readonly string DESCRIPTION = "Cool clean water. I can [FILL] a container with this.";

        public static readonly Commands.ItemType OBJECT_TYPE = Commands.ItemType.Water;

        public Water()
            : base(NAME, DESCRIPTION, OBJECT_TYPE, false) { }
    }
}
