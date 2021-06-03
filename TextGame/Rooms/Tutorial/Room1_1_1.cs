using System;
using System.Collections.Generic;
using TextGame.Items;
using TextGame.Items.InventoryItems;

namespace TextGame.Rooms.Tutorial
{
    class Room1_1_1 : Room
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

        private static readonly Dictionary<Directions, Type> ROOMS = new Dictionary<Directions, Type>()
        {
            { Directions.Northwest, null },
            { Directions.North, typeof(Room2_2_1) },
            { Directions.Northeast, null },
            { Directions.East, null },
            { Directions.Southeast, null },
            { Directions.South, null },
            { Directions.Southwest, null },
            { Directions.West, null },
            { Directions.Up, typeof(Room1_1_2) },
            { Directions.Down, null },
        };

        public Room1_1_1(TutorialRooms tutorialRooms, Context context = null)
            : base(SCENE, INITIAL_ITEMS_IN_ROOM, ROOMS, tutorialRooms, context: context) { }
    }
}
