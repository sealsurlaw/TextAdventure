using System;
using System.Collections.Generic;
using System.Text;

namespace TextGame.Actions
{
    class StatsAction
    {
        public static void Handle(List<string> keywords, Context context)
        {
            context.Stats.ViewStats();
        }
    }
}
