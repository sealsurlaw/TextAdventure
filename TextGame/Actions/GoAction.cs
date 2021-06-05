using System;
using System.Collections.Generic;
using TextGame.Helpers;

namespace TextGame.Actions
{
    static class GoAction
    {
        public static void Handle(List<string> keywords, Context context)
        {
            foreach (string keyword in keywords)
            {
                bool found = false;
                bool success = false;
                switch (keyword)
                {
                    case "northwest":
                    case "nw":
                        success = context.Room.GoTo(Rooms.Room.Directions.Northwest);
                        found = true;
                        break;
                    case "north":
                    case "n":
                        success = context.Room.GoTo(Rooms.Room.Directions.North);
                        found = true;
                        break;
                    case "northeast":
                    case "ne":
                        success = context.Room.GoTo(Rooms.Room.Directions.Northeast);
                        found = true;
                        break;
                    case "east":
                    case "e":
                        success = context.Room.GoTo(Rooms.Room.Directions.East);
                        found = true;
                        break;
                    case "southeast":
                    case "se":
                        success = context.Room.GoTo(Rooms.Room.Directions.Southeast);
                        found = true;
                        break;
                    case "south":
                    case "s":
                        success = context.Room.GoTo(Rooms.Room.Directions.South);
                        found = true;
                        break;
                    case "southwest":
                    case "sw":
                        success = context.Room.GoTo(Rooms.Room.Directions.Southwest);
                        found = true;
                        break;
                    case "west":
                    case "w":
                        success = context.Room.GoTo(Rooms.Room.Directions.West);
                        found = true;
                        break;
                    case "up":
                    case "u":
                        success = context.Room.GoTo(Rooms.Room.Directions.Up);
                        found = true;
                        break;
                    case "down":
                    case "d":
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
