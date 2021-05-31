using System;
using System.Collections.Generic;
using TextGame.Rooms;

namespace TextGame.Helpers
{
    static class Commands
    {
        public enum ActionType
        {
            Drink,
            Look,
            LookAt,
            Take,
            Inventory,
            Null,
        }

        public enum ObjectType
        {
            Coin,
            Fountain,
            Olive,
            Tree,
            Water,
            Null,
        }

        private static List<string> valuelessWords = new List<string>()
        {
            "at",
            "around",
            "in",
            "the",
            "to",
        };

        public static string Prompt()
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine();
            Console.Write(" ? ");
            Console.ForegroundColor = ConsoleColor.White;
            return Console.ReadLine();
        }

        public static Tuple<ActionType, ObjectType> ParseCommand(string command)
        {
            command = command.ToLower().Trim();
            List<string> commandSplit = new List<string>(command.Split(" "));
            RemoveValuelessWords(commandSplit);

            if (commandSplit.Count == 0)
            {
                return new Tuple<ActionType, ObjectType>(ActionType.Null, ObjectType.Null);
            }

            ActionType actionType = ParseAction(commandSplit[0], commandSplit.Count > 1);
            if (actionType == ActionType.Take)
            {
                commandSplit.RemoveAll(word => word == "up");
            }

            commandSplit.RemoveAt(0);
            ObjectType objectType = ParseObject(commandSplit);

            return new Tuple<ActionType, ObjectType>(actionType, objectType);
        }

        public static void InterpretCommands(ActionType actionType, ObjectType objectType, Context context)
        {
            if (actionType == ActionType.Look)
            {
                Console.Clear();
                context.Room.LookAt();
            }

            if (actionType == ActionType.LookAt)
            {
                if (context.Room.ContainsItem(objectType))
                {
                    context.Room.LookAt(objectType);
                }
                else if (context.Backpack.ContainsItem(objectType))
                {
                    context.Backpack.LookAt(objectType);
                }
                else
                {
                    Console.WriteLine("I don't see that here.");
                }
            }

            if (actionType == ActionType.Inventory)
            {
                context.Backpack.ViewContents();
            }

            if (actionType == ActionType.Take)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;

                Tuple<bool, Room.TakeReasons> successTuple = context.Room.TakeItem(objectType);
                if (successTuple.Item1)
                {
                    Console.WriteLine("You add the item to your backpack.");
                }
                else
                {
                    switch (successTuple.Item2)
                    {
                        case Room.TakeReasons.BackpackFull:
                            Console.WriteLine("You cannot take that. Your backpack is full.");
                            break;
                        case Room.TakeReasons.CannotTake:
                            Console.WriteLine("That is not something you can take.");
                            break;
                        case Room.TakeReasons.NotHere:
                            Console.WriteLine("I don't see that here.");
                            break;
                    }
                }

                Console.ResetColor();
            }
        }

        private static void RemoveValuelessWords(List<string> commandSplit)
        {
            commandSplit.RemoveAll(word => valuelessWords.Contains(word));
        }

        private static ActionType ParseAction(string action, bool containsObject)
        {
            switch (action)
            {
                case "drink":
                case "slurp":
                    return ActionType.Drink;
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

        private static ObjectType ParseObject(List<string> objs)
        {
            if (objs.Count == 0)
            {
                return ObjectType.Null;
            }

            foreach (string obj in objs)
            {
                switch (obj)
                {
                    case "coin":
                    case "coins":
                        return ObjectType.Coin;
                    case "fountain":
                        return ObjectType.Fountain;
                    case "olive":
                    case "olives":
                        if (objs.Contains("tree"))
                        {
                            return ObjectType.Tree;
                        }

                        return ObjectType.Olive;
                    case "tree":
                    case "trees":
                        return ObjectType.Tree;
                    case "water":
                        return ObjectType.Water;
                }
            }

            return ObjectType.Null;
        }
    }
}
