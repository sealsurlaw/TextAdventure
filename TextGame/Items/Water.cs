using TextGame.Helpers;

namespace TextGame.Items
{
    class Water : Item
    {
        public static readonly string NAME = "Water";

        public static readonly string DESCRIPTION = "Cool clean water. I can [FILL] a container with this.";

        public Water(Context context)
            : base(NAME, DESCRIPTION, false, context) { }

        public override string Drink()
        {
            Context.Stats.SubtractFromStat(Stats.StatType.Thirst, 10);
            return $"You drink the cool refreshing water. Your thirst is now {Context.Stats.GetStat(Stats.StatType.Thirst)}";
        }
    }
}
