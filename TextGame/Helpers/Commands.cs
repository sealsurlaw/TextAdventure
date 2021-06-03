using System;
using System.Collections.Generic;
using TextGame.Actions;
using TextGame.Items;
using TextGame.Items.InventoryItems;
using TextGame.Rooms;

namespace TextGame.Helpers
{
    static class Commands
    {
        /// <summary>
        /// The action commands.
        /// </summary>
        public enum ActionType
        {
            Drink,
            Fill,
            Go,
            Inventory,
            Look,
            LookAt,
            Take,
            Use,
            Null,
        }

        /// <summary>
        /// The item commands.
        /// </summary>
        public enum ItemType
        {
            Coin,
            Fountain,
            Olive,
            Tree,
            Water,
            Waterskin,
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
            Null,
        }

        public static string Prompt()
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine();
            Console.Write(" ? ");
            Console.ForegroundColor = ConsoleColor.White;
            return Console.ReadLine();
        }

        public static Tuple<ActionType, List<ItemType>> ParseCommand(string command)
        {
            command = command.ToLower().Trim();
            List<string> commandSplit = new List<string>(command.Split(" "));

            if (commandSplit.Count == 0)
            {
                return new Tuple<ActionType, List<ItemType>>(ActionType.Null, new List<ItemType>());
            }

            ActionType actionType = ParseAction(commandSplit[0], commandSplit.Count > 1);
            commandSplit.RemoveAt(0);
            List<ItemType> itemTypes = ParseItems(commandSplit);

            return new Tuple<ActionType, List<ItemType>>(actionType, itemTypes);
        }

        /// <summary>
        /// Interpret commands.
        /// </summary>
        /// <param name="actionType"></param>
        /// <param name="ItemType"></param>
        /// <param name="context"></param>
        public static void InterpretCommands(ActionType actionType, List<ItemType> itemTypes, Context context)
        {
            switch (actionType)
            {
                case ActionType.Drink:
                    DrinkAction.Handle(itemTypes, context);
                    break;
                case ActionType.Fill:
                    FillAction.Handle(itemTypes, context);
                    break;
                case ActionType.Go:
                    GoAction.Handle(itemTypes, context);
                    break;
                case ActionType.Inventory:
                    InventoryAction.Handle(itemTypes, context);
                    break;
                case ActionType.Look:
                    LookAction.Handle(itemTypes, context);
                    break;
                case ActionType.LookAt:
                    LookAtAction.Handle(itemTypes, context);
                    break;
                case ActionType.Take:
                    TakeAction.Handle(itemTypes, context);
                    break;
                case ActionType.Use:
                    UseAction.Handle(itemTypes, context);
                    break;
                default:
                    Console.WriteLine("I'm unable to help with that.");
                    break;
            }
        }

        private static ActionType ParseAction(string action, bool containsObject)
        {
            switch (action)
            {
                case "fill":
                    return ActionType.Fill;
                case "drink":
                case "slurp":
                    return ActionType.Drink;
                case "go":
                    return ActionType.Go;
                case "look":
                    if (containsObject)
                    {
                        return ActionType.LookAt;
                    }

                    return ActionType.Look;
                case "take":
                case "pick":
                    return ActionType.Take;
                case "inventory":
                case "backpack":
                case "bag":
                    return ActionType.Inventory;
                default:
                    return ActionType.Null;
            }
        }

        private static List<ItemType> ParseItems(List<string> objs)
        {
            List<ItemType> itemTypes = new List<ItemType>();
            if (objs.Count == 0)
            {
                return itemTypes;
            }

            foreach (string obj in objs)
            {
                switch (obj)
                {
                    case "coin":
                    case "coins":
                        itemTypes.Add(ItemType.Coin);
                        break;
                    case "fountain":
                        itemTypes.Add(ItemType.Fountain);
                        break;
                    case "olive":
                    case "olives":
                        if (objs.Contains("tree"))
                        {
                            itemTypes.Add(ItemType.Tree);
                        }

                        itemTypes.Add(ItemType.Olive);
                        break;
                    case "tree":
                    case "trees":
                        itemTypes.Add(ItemType.Tree);
                        break;
                    case "water":
                        itemTypes.Add(ItemType.Water);
                        break;
                    case "northwest":
                    case "nw":
                        itemTypes.Add(ItemType.Northwest);
                        break;
                    case "north":
                    case "n":
                        itemTypes.Add(ItemType.North);
                        break;
                    case "northeast":
                    case "ne":
                        itemTypes.Add(ItemType.Northeast);
                        break;
                    case "east":
                    case "e":
                        itemTypes.Add(ItemType.East);
                        break;
                    case "southeast":
                    case "se":
                        itemTypes.Add(ItemType.Southeast);
                        break;
                    case "south":
                    case "s":
                        itemTypes.Add(ItemType.South);
                        break;
                    case "southwest":
                    case "sw":
                        itemTypes.Add(ItemType.Southwest);
                        break;
                    case "west":
                    case "w":
                        itemTypes.Add(ItemType.West);
                        break;
                    case "up":
                    case "u":
                        itemTypes.Add(ItemType.Up);
                        break;
                    case "down":
                    case "d":
                        itemTypes.Add(ItemType.Down);
                        break;
                }
            }

            return itemTypes;
        }
    }
}
