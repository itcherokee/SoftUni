namespace Phonebook
{
    using System;
    using System.Linq;
    using Contracts;

    class Phonebook
    {
        private static readonly IPhonebookRepository phonebook = new PhonebookRepository();

        static void Main()
        {
            try
            {
                var commandLineData = Console.ReadLine();
                while (commandLineData != "End" && commandLineData != null)
                {
                    string command;
                    string[] parameters;
                    ParseCommandLine(commandLineData, out command, out parameters);
                    string result = ExecuteCommand(command, parameters);
                    Console.WriteLine(result);
                    commandLineData = Console.ReadLine();
                }
            }
            catch (InvalidOperationException e)
            {
                Console.WriteLine(e.Message);
            }
            catch (ArgumentException e)
            {
                Console.WriteLine(e.Message);
            }
        }

        private static void ParseCommandLine(string commandLineData, out string command, out string[] parameters)
        {
            int openBracketIndex = commandLineData.IndexOf('(');
            int closeBracketIndex = commandLineData.LastIndexOf(")", StringComparison.Ordinal);
            if (openBracketIndex == -1 || closeBracketIndex == -1)
            {
                throw new InvalidOperationException("Invalid command entered");
            }

            command = commandLineData.Substring(0, openBracketIndex);
            parameters = commandLineData
                .Substring(openBracketIndex + 1, commandLineData.Length - openBracketIndex - 2)
                .Split(',').Select(x => x.Trim()).ToArray();
        }

        private static string ExecuteCommand(string command, string[] commandParameters)
        {
            string commandResult;
            switch (command)
            {
                case "AddPhone":
                    if (commandParameters.Length >= 2)
                    {
                        string name = commandParameters[0];
                        var phoneNumbers = commandParameters.Skip(1).ToList();
                        bool isNewEntry = phonebook.AddPhone(name, phoneNumbers);
                        commandResult = isNewEntry ? "Phone entry created" : "Phone entry merged";
                    }
                    else
                    {
                        throw new ArgumentException(string.Format("Invalid number of parameters provided with '{0}' command", command), "commandParameters");
                    }

                    break;

                case "ChangePhone":
                    if (commandParameters.Length == 2)
                    {
                        var oldPhoneNumber = commandParameters[0];
                        var newPhoneNumber = commandParameters[1];
                        var numberOfPhoneNumbersChanged = phonebook.ChangePhone(oldPhoneNumber, newPhoneNumber);
                        commandResult = numberOfPhoneNumbersChanged + " numbers changed";
                    }
                    else
                    {
                        throw new ArgumentException(string.Format("Invalid number of parameters provided with '{0}' command", command), "commandParameters");
                    }
                    
                    break;

                case "List":
                    try
                    {
                        if (commandParameters.Length == 2)
                        {
                            var startIndex = int.Parse(commandParameters[0]);
                            var count = int.Parse(commandParameters[1]);
                            var entries = phonebook.ListEntries(startIndex, count);
                            commandResult = string.Join("\n", entries);
                        }
                        else
                        {
                            throw new ArgumentException(string.Format("Invalid number of parameters provided with '{0}' command", command), "commandParameters");
                        }
                    }
                    catch (ArgumentOutOfRangeException)
                    {
                        commandResult = "Invalid range";
                    }
                    
                    break;
               
                default:
                    throw new InvalidOperationException("Invalid command provided.");
            }

            return commandResult;
        }
    }
}
