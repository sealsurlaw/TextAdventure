using System.Collections.Generic;
using TextGame.Helpers;

namespace TextGame.Actions
{
    static class InventoryAction
    {
        public static void Handle(List<string> keywords, Context context)
        {
                context.Backpack.ViewContents();
        }
    }
}
