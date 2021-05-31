using System.Collections.Generic;
using TextGame.Items;
using TextGame.Items.InventoryItems;

namespace TextGame.Rooms
{

    class Room1_1 : Room
    {
        private static readonly string SCENE = "You are standing in the middle of a courtyard. An ancient {OLIVE TREE} twists up to the exposed sky. Hundreds of {OLIVES} dot the branches inviting you to [TAKE] one. There's a {FOUNTAIN} in the middle of the courtyard with sparkling clear {WATER}.";

        private static readonly List<Item> INITIAL_ITEMS_IN_ROOM = new List<Item>()
        {
            new CopperCoin(),
            new Fountain(),
            new Olive(),
            new OliveTree(),
            new Water(),
        };

        public Room1_1(Context context = null)
            : base(SCENE, INITIAL_ITEMS_IN_ROOM, context: context) { }
    }
}
