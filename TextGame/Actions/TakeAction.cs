using System;
using System.Collections.Generic;
using TextGame.Helpers;
using TextGame.Rooms;

namespace TextGame.Actions
{
    static class TakeAction
    {
        public static void Handle(List<string> keywords, Context context)
        {
            if (keywords.Count == 0)
            {
                Console.WriteLine("I don't see that here.");
                return;
            }

            Console.ForegroundColor = ConsoleColor.Yellow;

            Tuple<bool, Room.TakeReasons> successTuple = context.Room.TakeItem(keywords);
            if (successTuple.Item1)
            {
                Console.WriteLine("You add the item to your backpack.");
            }
            else
            {
                switch (successTuple.Item2)
                {
                    case Room.TakeReasons.BackpackFull:
                        Console.WriteLine("You can't take that. Your backpack is full.");
                        break;
                    case Room.TakeReasons.CannotTake:
                        Console.WriteLine("That is not something you can take.");
                        break;
                    case Room.TakeReasons.NotHere:
                        Console.WriteLine("I don't see that here.");
                        break;
                }
            }
        }
    }
}
