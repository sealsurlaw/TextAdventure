using System;

namespace TextGame.Helpers
{
    static class Processor
    {
        public static void ProcessEvents(Context context)
        {
            TimeSpan timeElapsed = DateTime.Now - context.LastCheckedForEvents;
            context.LastCheckedForEvents = DateTime.Now;

            context.Stats.AddToStat(Stats.StatType.Thirst, (uint)timeElapsed.TotalSeconds / 10);
            if (context.Stats.GetStat(Stats.StatType.Thirst) > 1)
            {
                PrintHelper.WarningPrint("You are very thirsty.");
            }
        }
    }
}
