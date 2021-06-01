using TextGame.Helpers;

namespace TextGame.Items
{
    class OliveTree : Item
    {
        public static readonly string NAME = "Olive Tree";

        public static readonly string DESCRIPTION = "An olive tree covered in many tiny {OLIVES}. Its twisting bark indicates that its been here longer than the courtyard around it.";

        public static readonly Commands.ItemType OBJECT_TYPE = Commands.ItemType.Tree;

        public OliveTree()
            : base(NAME, DESCRIPTION, OBJECT_TYPE, false) { }
    }
}
