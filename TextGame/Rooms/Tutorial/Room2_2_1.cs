using System;
using System.Collections.Generic;
using TextGame.Items;
using TextGame.Items.InventoryItems;

namespace TextGame.Rooms.Tutorial
{
    class Room2_2_1 : Room
    {
        private static readonly string SCENE = "A potted {CACTUS} sits in the corner.";

        private static readonly List<Item> INITIAL_ITEMS_IN_ROOM = new List<Item>()
        {
            new Cactus(),
        };

        private static readonly Dictionary<Directions, Type> ROOMS = new Dictionary<Directions, Type>()
        {
            { Directions.Northwest, null },
            { Directions.North, null },
            { Directions.Northeast, null },
            { Directions.East, null },
            { Directions.Southeast, null },
            { Directions.South, typeof(Room1_1_1) },
            { Directions.Southwest, null },
            { Directions.West, null },
            { Directions.Up, null },
            { Directions.Down, null },
        };

        public Room2_2_1(TutorialRooms tutorialRooms, Context context = null)
            : base(SCENE, INITIAL_ITEMS_IN_ROOM, ROOMS, tutorialRooms, context: context) { }
    }
}
