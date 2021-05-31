﻿using System;
using TextGame.Helpers;
using TextGame.Rooms;

namespace TextGame
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.ResetColor();

            Context context = new Context();
            context.Room = new Room1_1(context: context);
            context.Room.LookAt();

            string command = string.Empty;
            while (command.ToLower() != "exit")
            {
                command = Commands.Prompt();
                if (string.IsNullOrWhiteSpace(command))
                {
                    continue;
                }

                Console.WriteLine();

                Tuple<Commands.ActionType, Commands.ObjectType> parsedCommand = Commands.ParseCommand(command);
                Commands.ActionType actionType = parsedCommand.Item1;
                Commands.ObjectType objectType = parsedCommand.Item2;

                Commands.InterpretCommands(actionType, objectType, context);
            }
        }
    }
}
