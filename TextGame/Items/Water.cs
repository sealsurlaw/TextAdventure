using TextGame.Helpers;

namespace TextGame.Items
{
    class Water : Item
    {
        public static readonly string NAME = "Water";

        public static readonly string DESCRIPTION = "Cool clean water. I can [FILL] a container with this.";

        public static readonly Commands.ObjectType OBJECT_TYPE = Commands.ObjectType.Water;

        public Water()
            : base(NAME, DESCRIPTION, OBJECT_TYPE, false) { }
    }
}
