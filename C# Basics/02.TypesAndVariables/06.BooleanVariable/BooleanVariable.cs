namespace PrimitiveDataTypesAndVariables
{
    using System;

    /// <summary>
    /// Task:   6. Declare a Boolean variable called isFemale and assign an appropriate value corresponding to 
    ///         your gender. Print it on the console.
    /// </summary>
    public class BooleanVariable
    {
        public static void Main()
        {
            Console.Title = "Check your gender";
            bool isFemale = true;
            byte number = EnterValue();
            if (number % 2 == 0)
            {
                isFemale = false;
            }
            else
            {
                isFemale = true;
            }

            Console.WriteLine("You are {0}.", Enum.GetName(typeof(Gender), isFemale ? 1 : 0));
            Console.ReadKey();
        }

        private enum Gender
        {
            Male,
            Female,
        }

        private static byte EnterValue()
        {
            bool isValidInput = false;
            byte number = new byte(); // :)
            do
            {
                Console.ForegroundColor = ConsoleColor.White;
                Console.Write("Please, enter the number before last from your UCN (ЕГН): ");
                Console.ForegroundColor = ConsoleColor.Yellow;
                isValidInput = byte.TryParse(Console.ReadLine(), out number);
                if (!isValidInput || (number > 9))
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Invalid input! Try again.");
                    isValidInput = false;
                }
            } while (!isValidInput);

            return number;
        }
    }
}