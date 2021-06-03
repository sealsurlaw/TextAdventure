using System;
using System.Collections.Generic;

namespace TextGame.Rooms.Tutorial
{
    class TutorialRooms
    {
        private readonly Dictionary<Type, Room> rooms;

        public TutorialRooms(Context context)
        {
            rooms = new Dictionary<Type, Room>()
            {
                { typeof(Room1_1_1), new Room1_1_1(this, context) },
                { typeof(Room1_1_2), new Room1_1_2(this, context) },
                { typeof(Room2_2_1), new Room2_2_1(this, context) },
            };
        }

        public Room Get(Type type)
        {
            return rooms.GetValueOrDefault(type);
        }
    }
}
