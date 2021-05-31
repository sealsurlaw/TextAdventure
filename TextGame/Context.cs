using TextGame.Rooms;

namespace TextGame
{
    class Context
    {
        public Stats Stats;

        public Backpack Backpack;

        public Room Room;

        public Context()
        {
            Stats = new Stats();
            Backpack = new Backpack(stats: Stats);
        }
    }
}
