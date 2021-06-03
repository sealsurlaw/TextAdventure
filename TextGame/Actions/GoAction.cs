using System;
using System.Collections.Generic;
using TextGame.Helpers;

namespace TextGame.Actions
{
    static class GoAction
    {
        public static void Handle(List<Commands.ItemType> itemTypes, Context context)
        {
            foreach (Commands.ItemType itemType in itemTypes)
            {
                bool found = false;
                bool success = false;
                switch (itemType)
                {
                    case Commands.ItemType.Northwest:
                        success = context.Room.GoTo(Rooms.Room.Directions.Northwest);
                        found = true;
                        break;
                    case Commands.ItemType.North:
                        success = context.Room.GoTo(Rooms.Room.Directions.North);
                        found = true;
                        break;
                    case Commands.ItemType.Northeast:
                        success = context.Room.GoTo(Rooms.Room.Directions.Northeast);
                        found = true;
                        break;
                    case Commands.ItemType.East:
                        success = context.Room.GoTo(Rooms.Room.Directions.East);
                        found = true;
                        break;
                    case Commands.ItemType.Southeast:
                        success = context.Room.GoTo(Rooms.Room.Directions.Southeast);
                        found = true;
                        break;
                    case Commands.ItemType.South:
                        success = context.Room.GoTo(Rooms.Room.Directions.South);
                        found = true;
                        break;
                    case Commands.ItemType.Southwest:
                        success = context.Room.GoTo(Rooms.Room.Directions.Southwest);
                        found = true;
                        break;
                    case Commands.ItemType.West:
                        success = context.Room.GoTo(Rooms.Room.Directions.West);
                        found = true;
                        break;
                    case Commands.ItemType.Up:
                        success = context.Room.GoTo(Rooms.Room.Directions.Up);
                        found = true;
                        break;
                    case Commands.ItemType.Down:
                        success = context.Room.GoTo(Rooms.Room.Directions.Down);
                        found = true;
                        break;
                }

                if (found && !success)
                {
                    Console.WriteLine("You cannot go that way.");
                    return;
                }

                if (success)
                {
                    return;
                }
            }

            Console.WriteLine("That doesn't appear to be a direction.");
        }
    }
}
