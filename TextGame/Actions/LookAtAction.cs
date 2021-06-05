using System;
using System.Collections.Generic;
using TextGame.Helpers;
using TextGame.Items;

namespace TextGame.Actions
{
    static class LookAtAction
    {
        public static void Handle(List<string> keywords, Context context)
        {
            Tuple<Item, float> roomHighest = context.Room.GetMostLikelyMatch(keywords);
            Tuple<Item, float> backpackHighest = context.Backpack.GetMostLikelyMatch(keywords);

            if (Math.Max(roomHighest.Item2, backpackHighest.Item2) == 0f)
            {
                Console.WriteLine("I don't see that here.");
                return;
            }

            Console.WriteLine($"{roomHighest.Item1} {roomHighest.Item2}");
            Console.WriteLine($"{backpackHighest.Item1} {backpackHighest.Item2}");

            Item highestItem = roomHighest.Item1;
            if (backpackHighest.Item2 > roomHighest.Item2)
            {
                highestItem = backpackHighest.Item1;
            }

            PrintHelper.ColorPrint(highestItem.LookAt());
        }
    }
}
