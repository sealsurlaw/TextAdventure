using TextGame.Rooms;
using TextGame.Rooms.Tutorial;

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
            TutorialRooms tutorialRooms = new TutorialRooms(this);
            Room = tutorialRooms.Get(typeof(Room1_1_1));
        }
    }
}
