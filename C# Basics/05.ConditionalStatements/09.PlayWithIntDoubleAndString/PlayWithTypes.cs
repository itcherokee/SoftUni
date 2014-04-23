namespace ConditionalStatements
{
    using System;

    /// <summary>
    /// Task 9: Write a program that, depending on the user’s choice, inputs an int, double or string variable.
    ///         If the variable is int or double, the program increases it by one. If the variable is a string, 
    ///         the program appends "*" at the end. Print the result at the console. Use switch statement.
    /// </summary>
    public class PlayWithTypes
    {
        public static void Main()
        {
            Console.Title = "Recognize user input type";
            bool isValidSelect = false;
            do
            {
                Console.WriteLine("Please choose a type:");
                Console.WriteLine("1 --> int ");
                Console.WriteLine("2 --> double");
                Console.WriteLine("3 --> string");
                Console.Write("Make you selection [1..3]: ");
                bool isValidInput;
                switch (Console.ReadLine())
                {
                    case "1":
                        int inputValueInt = 0;
                        do
                        {
                            Console.Write("Please enter an int: ");
                            isValidInput = int.TryParse(Console.ReadLine(), out inputValueInt);
                            inputValueInt++;
                        }
                        while (!isValidInput);

                        isValidSelect = false;
                        Console.WriteLine("The entered value +1 is: {0}", inputValueInt);
                        break;
                    case "2":
                        double inputValueDouble = 0.0;
                        do
                        {
                            Console.Write("Please enter a double: ");
                            isValidInput = double.TryParse(Console.ReadLine(), out inputValueDouble);
                            inputValueDouble++;
                        }
                        while (!isValidInput);

                        isValidSelect = false;
                        Console.WriteLine("The entered value +1 is: {0}", inputValueDouble);
                        break;
                    case "3":
                        Console.Write("Please enter a string: ");
                        string inputValueString = Console.ReadLine();
                        inputValueString += "*";
                        isValidSelect = false;
                        Console.WriteLine("The entered value + \"*\" symbol is: {0}", inputValueString);
                        break;
                    default:
                        Console.WriteLine("There is no such selector, try again. Press a key...");
                        Console.ReadKey();
                        Console.Clear();
                        isValidSelect = true;
                        break;
                }
            }
            while (isValidSelect);
        }
    }
}