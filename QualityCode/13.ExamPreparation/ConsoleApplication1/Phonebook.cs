namespace Phonebook
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using Contracts;

    class Phonebook
    {
        private const char PlusSymbol = '+';
        private const string DefaultShortCountryCode = "+359";
        private const string DefaultLongCountryCode = "00359";
        private const string AddPhoneCommand = "AddPhone";
        private const string ChangePhoneCommand = "ChangePhone";
        private const string ListPhonesCommand = "List";
        private const string EndCommand = "End";

        private static readonly IPhonebookRepository data = new PhonebookRepository();

        static void Main()
        {
            var output = new StringBuilder();
            while (true)
            {
                string consoleInput = Console.ReadLine();

                if (consoleInput == EndCommand || consoleInput == null)
                {
                    break;
                }

                int openBracketIndex = consoleInput.IndexOf('(');
                if (openBracketIndex == -1 || !consoleInput.EndsWith(")"))
                {
                    throw new InvalidOperationException("Invalid command line provided!");
                }

                string inputCommand = consoleInput.Substring(0, openBracketIndex);
                string parsedParameters = consoleInput.Substring(openBracketIndex + 1,
                    consoleInput.Length - openBracketIndex - 2);
                string[] inputParameters = parsedParameters.Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries);

                output.AppendLine(ExecuteCommand(inputCommand, inputParameters));
            }

            Console.Write(output);
        }

        private static string ExecuteCommand(string command, string[] commandParams)
        {
            var result = string.Empty;
            switch (command)
            {
                case AddPhoneCommand:
                    if (commandParams.Length >= 2)
                    {
                        result = ExecuteAddPhoneCommand(commandParams);
                    }
                    else
                    {
                        throw new InvalidOperationException("Invalid command provided");
                    }

                    break;
                case ChangePhoneCommand:
                    if (commandParams.Length == 2)
                    {
                        result = ExecuteChangePhoneCommand(commandParams);
                    }
                    else
                    {
                        throw new InvalidOperationException("Invalid command provided");
                    }

                    break;
                case ListPhonesCommand:
                    if (commandParams.Length == 2)
                    {
                        result = ExecuteListPhonesCommand(commandParams);
                    }
                    else
                    {
                        throw new InvalidOperationException("Invalid command provided");
                    }

                    break;
                default:
                    throw new InvalidOperationException("Invalid command provided");
                    break;
            }

            return result;
        }

        private static string ExecuteListPhonesCommand(string[] commandParams)
        {
            var result = string.Empty;

            try
            {
                var entries = data.ListEntries(int.Parse(commandParams[0]), int.Parse(commandParams[1]));
                result = string.Join("\n", entries);
            }
            catch (ArgumentOutOfRangeException)
            {
                result = "Invalid range";
            }

            return result;
        }

        private static string ExecuteChangePhoneCommand(string[] commandParams)
        {
            var oldPhoneNumber = ConvertPhoneToCanonicalForm(commandParams[0]);
            var newPhoneNumber = ConvertPhoneToCanonicalForm(commandParams[1]);
            var countOfPhoneNumbersChanged = data.ChangePhone(oldPhoneNumber, newPhoneNumber);
            string result = countOfPhoneNumbersChanged + " numbers changed";
            return result;
        }

        private static string ExecuteAddPhoneCommand(string[] commandParams)
        {
            var phoneName = commandParams[0].Trim();
            var phoneNumbers = commandParams.Skip(1).Select(p => p.Trim()).ToList();

            for (int i = 0; i < phoneNumbers.Count; i++)
            {
                phoneNumbers[i] = ConvertPhoneToCanonicalForm(phoneNumbers[i]);
            }

            bool isNewEntry = data.AddPhone(phoneName, phoneNumbers);

            string result = isNewEntry ? "Phone entry created" : "Phone entry merged";

            return result;
        }

        private static string ConvertPhoneToCanonicalForm(string inputPhoneNumber)
        {
            const int MaxPhoneNumberLength = 50;

            var canonicalNumber = new StringBuilder(MaxPhoneNumberLength);

            for (int index = 0; index < inputPhoneNumber.Length; index++)
            {
                if (index == MaxPhoneNumberLength)
                {
                    break;
                }

                if (char.IsDigit(inputPhoneNumber[index]) || inputPhoneNumber[index] == PlusSymbol)
                {
                    canonicalNumber.Append(inputPhoneNumber[index]);
                }
            }

            if (canonicalNumber.ToString().StartsWith("00359"))
            {
                canonicalNumber.Remove(0, DefaultLongCountryCode.Length);
            }

            if (canonicalNumber.ToString().StartsWith("0"))
            {
                canonicalNumber.Remove(0, 1);
            }

            if (canonicalNumber[0] != PlusSymbol)
            {
                canonicalNumber.Insert(0, DefaultShortCountryCode);
            }

            return canonicalNumber.ToString();
        }
    }
}

