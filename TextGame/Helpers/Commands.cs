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
            Stats,
            Inventory,
            Look,
            LookAt,
            Take,
            Use,
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

        public static Tuple<ActionType, List<string>> ParseCommand(string command)
        {
            command = command.ToLower().Trim();
            List<string> commandSplit = new List<string>(command.Split(" "));

            if (commandSplit.Count == 0)
            {
                return new Tuple<ActionType, List<string>>(ActionType.Null, null);
            }

            ActionType actionType = ParseAction(commandSplit[0], commandSplit.Count > 1);
            if (actionType != ActionType.Go)
            {
                commandSplit.RemoveAt(0);
            }

            return new Tuple<ActionType, List<string>>(actionType, commandSplit);
        }

        /// <summary>
        /// Interpret commands.
        /// </summary>
        /// <param name="actionType"></param>
        /// <param name="ItemType"></param>
        /// <param name="context"></param>
        public static void InterpretCommands(ActionType actionType, List<string> keywords, Context context)
        {
            switch (actionType)
            {
                case ActionType.Drink:
                    DrinkAction.Handle(keywords, context);
                    break;
                case ActionType.Fill:
                    FillAction.Handle(keywords, context);
                    break;
                case ActionType.Go:
                    GoAction.Handle(keywords, context);
                    break;
                case ActionType.Stats:
                    StatsAction.Handle(keywords, context);
                    break;
                case ActionType.Inventory:
                    InventoryAction.Handle(keywords, context);
                    break;
                case ActionType.Look:
                    LookAction.Handle(keywords, context);
                    break;
                case ActionType.LookAt:
                    LookAtAction.Handle(keywords, context);
                    break;
                case ActionType.Take:
                    TakeAction.Handle(keywords, context);
                    break;
                case ActionType.Use:
                    UseAction.Handle(keywords, context);
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
                case "northwest":
                case "nw":
                case "north":
                case "n":
                case "northeast":
                case "ne":
                case "east":
                case "e":
                case "southeast":
                case "se":
                case "south":
                case "s":
                case "southwest":
                case "sw":
                case "west":
                case "w":
                case "up":
                case "u":
                case "down":
                case "d":
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
                case "stats":
                    return ActionType.Stats;
                case "inventory":
                case "backpack":
                case "bag":
                case "i":
                    return ActionType.Inventory;
                default:
                    return ActionType.Null;
            }
        }
    }
}
