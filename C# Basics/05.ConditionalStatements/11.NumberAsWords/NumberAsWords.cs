namespace ConditionalStatements
{
    using System;
    using System.Globalization;
    using System.Text;
    using System.Threading;

    /// <summary>
    /// Task 11: Write a program that converts a number in the range [0…999] to words, 
    ///          corresponding to the English pronunciation. 
    /// </summary>
    public class NumberAsWords
    {
        public static void Main()
        {
            Console.Title = "Convert Number to Words";
            string[] numberNames = 
                                  {
                                      "zero", "one", "two", "three", "four", "five", "six", "seven", "eight",
                                      "nine", "ten", "eleven", "twelve", "thirteen", "fourteen", "fifteen",
                                      "sixteen", "seventeen", "eighteen", "nineteen", "twenty", "thirty",
                                      "forty", "fifty", "eighty", "hundred", "ty"
                                  };
            string initialNumber = default(string);
            var finalTranslation = new StringBuilder();
            bool isValidInput;
            do
            {
                Console.ForegroundColor = ConsoleColor.White;
                Console.Write("Enter a number [0..999] to translate it to English: ");
                Console.ForegroundColor = ConsoleColor.Yellow;
                var userInput = new StringBuilder(Console.ReadLine());
                int userInputAsNumber;
                isValidInput = int.TryParse(userInput.ToString(), out userInputAsNumber);
                if (isValidInput && userInputAsNumber >= 0 && userInputAsNumber <= 999)
                {
                    isValidInput = false;
                    initialNumber = userInput.ToString();
                    CultureInfo cultureInfo = Thread.CurrentThread.CurrentCulture;
                    TextInfo textInfo = cultureInfo.TextInfo;

                    // Separate hundreds/tens/units
                    int hundreds = userInputAsNumber / 100;
                    int tens = (userInputAsNumber / 10) % 10;
                    int units = userInputAsNumber % 10;
                    bool sentenced = false;

                    // Checks for zero
                    if (userInputAsNumber == 0)
                    {
                        finalTranslation.Append(textInfo.ToTitleCase(numberNames[units]));
                        userInput.Length = 0;
                    }
                    else
                    {
                        // Assigns hundreds
                        if (userInput.Length == 3)
                        {
                            finalTranslation.Append(textInfo.ToTitleCase(numberNames[hundreds] + " "));
                            sentenced = true;
                            finalTranslation.Append(numberNames[25]);
                            if ((hundreds != 0) && ((tens != 0) || (units != 0)))
                            {
                                finalTranslation.Append(" and ");
                            }

                            // Removes the hundreds
                            userInput.Remove(0, 1);
                        }

                        // Assigns tens
                        if ((userInput.Length == 2) && (tens != 0))
                        {
                            string tensName = string.Empty;
                            switch (tens)
                            {
                                case 1:
                                    tensName = numberNames[tens + 9 + units];
                                    userInput.Length = 1;
                                    break;
                                case 2:
                                    tensName = numberNames[20];
                                    break;
                                case 3:
                                    tensName = numberNames[21];
                                    break;
                                case 4:
                                    tensName = numberNames[22];
                                    break;
                                case 5:
                                    tensName = numberNames[23];
                                    break;
                                case 6:
                                    tensName = numberNames[tens] + numberNames[26];
                                    break;
                                case 7:
                                    tensName = numberNames[tens] + numberNames[26];
                                    break;
                                case 8:
                                    tensName = numberNames[24];
                                    break;
                                case 9:
                                    tensName = numberNames[tens] + numberNames[26];
                                    break;
                            }

                            if (sentenced)
                            {
                                finalTranslation.Append(tensName);
                            }
                            else
                            {
                                finalTranslation.Append(textInfo.ToTitleCase(tensName));
                                sentenced = true;
                            }

                            // Removes the tens
                            userInput.Remove(0, 1);
                        }
                        else if (tens == 0 && hundreds != 0)
                        {
                            // Removes the tens
                            userInput.Remove(0, 1);
                        }

                        // Assigns units
                        if (userInput.Length == 1)
                        {
                            if ((tens != 0) && (units != 0))
                            {
                                finalTranslation.Append(" ");
                            }

                            if (units != 0)
                            {
                                finalTranslation.Append(sentenced
                                    ? numberNames[units]
                                    : textInfo.ToTitleCase(numberNames[units]));
                            }
                        }
                    }
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Input was not a number or out of scope, please try again.");
                    Console.ReadKey();
                    Console.Clear();
                    isValidInput = true;
                }
            }
            while (isValidInput);

            Console.Write("Translation of {0} is: ", initialNumber);
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("\"{0}\"", finalTranslation);
            Console.ForegroundColor = ConsoleColor.White;
            Console.ReadKey();
        }
    }
}