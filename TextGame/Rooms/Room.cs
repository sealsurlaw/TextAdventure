using System;
using System.Collections.Generic;
using TextGame.Helpers;
using TextGame.Items;
using TextGame.Items.InventoryItems;
using TextGame.Rooms.Tutorial;

namespace TextGame.Rooms
{
    abstract class Room
    {
        private readonly Context context;

        public enum Directions
        {
            Undefined,
            Northwest,
            North,
            Northeast,
            East,
            Southeast,
            South,
            Southwest,
            West,
            Up,
            Down,
        }

        public enum TakeReasons
        {
            CannotTake,
            NotHere,
            BackpackFull,
            Success,
        }

        public TutorialRooms TutorialRooms { get; }

        /// <summary>
        /// The scene of the room.
        /// </summary>
        public string Scene { get; }

        public List<Item> ItemsInRoom { get; }

        public Dictionary<Directions, Type> Rooms { get; private set; }

        public Room(
            string scene,
            List<Item> itemsInRoom,
            Dictionary<Directions, Type> rooms,
            TutorialRooms tutorialRooms,
            Context context = null)
        {
            this.context = context;

            TutorialRooms = tutorialRooms;
            Scene = scene;
            ItemsInRoom = itemsInRoom;
            Rooms = rooms;
        }

        public bool GoTo(Directions direction)
        {
            Type type = Rooms.GetValueOrDefault(direction);
            if (type == default)
            {
                return false;
            }

            Room room = TutorialRooms.Get(type);
            context.Room = room;
            context.Room.LookAt();
            return true;
        }

        private void CreateMap()
        {
            List<List<Directions>> map = new List<List<Directions>>()
            {
                new List<Directions>() { Directions.Northwest, Directions.Undefined, Directions.North, Directions.Undefined, Directions.Northeast },
                new List<Directions>() { Directions.West, Directions.Down, Directions.Undefined, Directions.Up, Directions.East },
                new List<Directions>() { Directions.Southwest, Directions.Undefined, Directions.South, Directions.Undefined, Directions.Southeast },
            };

            foreach (List<Directions> row in map)
            {
                foreach (Directions direction in row)
                {
                    string symbol = string.Empty;
                    switch (direction)
                    {
                        case Directions.Northwest:
                            symbol = "NW ";
                            break;
                        case Directions.North:
                            symbol = " N ";
                            break;
                        case Directions.Northeast:
                            symbol = " NE";
                            break;
                        case Directions.East:
                            symbol = "  E";
                            break;
                        case Directions.Southeast:
                            symbol = " SE";
                            break;
                        case Directions.South:
                            symbol = " S ";
                            break;
                        case Directions.Southwest:
                            symbol = "SW ";
                            break;
                        case Directions.West:
                            symbol = "W  ";
                            break;
                        case Directions.Up:
                            symbol = " U ";
                            break;
                        case Directions.Down:
                            symbol = " D ";
                            break;
                        case Directions.Undefined:
                            symbol = "   ";
                            break;
                    }

                    if (direction != Directions.Undefined && Rooms[direction] != null)
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.Write(symbol);
                        Console.ResetColor();
                    }
                    else if (direction == Directions.Undefined)
                    {
                        Console.ForegroundColor = ConsoleColor.Gray;
                        Console.Write(" - ");
                        Console.ResetColor();
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Gray;
                        Console.Write(symbol);
                        Console.ResetColor();
                    }
                }

                Console.WriteLine();
                Console.WriteLine();
            }
        }

        /// <summary>
        /// Look at the room.
        /// </summary>
        public void LookAt()
        {
            Console.Clear();
            CreateMap();
            PrintHelper.ColorPrint(Scene);
            Console.WriteLine();
        }

        /// <summary>
        /// Look at an item in the room.
        /// </summary>
        /// <param name="itemName">The item name</param>
        public void LookAt(Commands.ItemType ItemType)
        {
            Item item = ItemsInRoom.Find(item => item.ItemType == ItemType);
            if (item == null)
            {
                Console.WriteLine("I don't see that here.");
                return;
            }

            PrintHelper.ColorPrint(item.Description);
        }

        /// <summary>
        /// Take an item from a room.
        /// </summary>
        /// <param name="name">The item name</param>
        /// <returns>Whether the item was taken and the reason if failed</returns>
        public Tuple<bool, TakeReasons> TakeItem(Commands.ItemType ItemType)
        {
            Item item = ItemsInRoom.Find(item => item.ItemType == ItemType);
            if (item == null)
            {
                return new Tuple<bool, TakeReasons>(false, TakeReasons.NotHere);
            }

            if (item.TryGetInventoryItem(out InventoryItem inventoryItem))
            {
                inventoryItem = inventoryItem.Clone();
                inventoryItem.Quantity = 1;
                bool success = context.Backpack.AddItem(inventoryItem.Clone()) && TryRemoveItem(item);
                if (success)
                {
                    return new Tuple<bool, TakeReasons>(true, TakeReasons.Success);
                }

                return new Tuple<bool, TakeReasons>(false, TakeReasons.BackpackFull);
            }

            return new Tuple<bool, TakeReasons>(false, TakeReasons.CannotTake);
        }

        public bool ContainsItem(Commands.ItemType ItemType)
        {
            return ItemsInRoom.Exists(item => item.ItemType == ItemType);
        }

        public Item GetItem(Commands.ItemType ItemType)
        {
            return ItemsInRoom.Find(item => item.ItemType == ItemType);
        }

        private bool TryRemoveItem(Item item, uint quantity = 1)
        {
            // If it's an inventory item (with quantity), handle subtracting from the quantity.
            if (item.TryGetInventoryItem(out InventoryItem inventoryItem))
            {
                if (inventoryItem.Quantity < quantity)
                {
                    return false;
                }

                inventoryItem.Quantity -= quantity;

                if (inventoryItem.Quantity == 0)
                {
                    ItemsInRoom.Remove(item);
                }

                return true;
            }

            // If it's not an inventory item, remove it from the list.
            return ItemsInRoom.Remove(item);
        }
    }
}
