using System;
using System.Collections.Generic;
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

                Tuple<Commands.ActionType, List<string>> parsedCommand = Commands.ParseCommand(command);
                Commands.ActionType actionType = parsedCommand.Item1;
                List<string> keywords = parsedCommand.Item2;

                Commands.InterpretCommands(actionType, keywords, context);
            }
        }
    }
}
