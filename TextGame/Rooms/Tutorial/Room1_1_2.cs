using System;
using System.Collections.Generic;
using TextGame.Items;
using TextGame.Items.InventoryItems;

namespace TextGame.Rooms.Tutorial
{
    class Room1_1_2 : Room
    {
        private static readonly string SCENE = "You are at the top of the {OLIVE TREE} surrounded by {OLIVES}. A {SWORD} is stuck into the side of the tree.";

        private static readonly List<Item> INITIAL_ITEMS_IN_ROOM = new List<Item>()
        {
            new Olive(),
            new OliveTree(),
            new Sword(),
        };

        private static readonly Dictionary<Directions, Type> ROOMS = new Dictionary<Directions, Type>()
        {
            { Directions.Northwest, null },
            { Directions.North, null },
            { Directions.Northeast, null },
            { Directions.East, null },
            { Directions.Southeast, null },
            { Directions.South, null },
            { Directions.Southwest, null },
            { Directions.West, null },
            { Directions.Up, null },
            { Directions.Down, typeof(Room1_1_1) },
        };

        public Room1_1_2(TutorialRooms tutorialRooms, Context context = null)
            : base(SCENE, INITIAL_ITEMS_IN_ROOM, ROOMS, tutorialRooms, context: context) { }
    }
}
