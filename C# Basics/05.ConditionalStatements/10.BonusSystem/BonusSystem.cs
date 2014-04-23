using System;

/// <summary>
/// Task: "10. Write a program that applies bonus scores to given scores in the range [1..9]. 
/// The program reads a digit as an input. If the digit is between 1 and 3, the program 
/// multiplies it by 10; if it is between 4 and 6, multiplies it by 100; if it is between 
/// 7 and 9, multiplies it by 1000. If it is zero or if the value is not a digit, the program 
/// must report an error. Use a switch statement and at the end print the calculated new value
/// in the console."
/// </summary>
public class BonusSystem
{
    public static void Main()
    {
        Console.Title = "Bonus System";
        string inputValue = default(string);
        bool isValidInput = false;
        do
        {
            Console.Write("Type your score [1..9] in order to see the total score (+bonus): ");
            inputValue = Console.ReadLine();
            switch (inputValue)
            {
                case "1":
                case "2":
                case "3":
                    CheckCalcAndPrint(inputValue, 10);
                    isValidInput = false;
                    break;
                case "4":
                case "5":
                case "6":
                    CheckCalcAndPrint(inputValue, 100);
                    isValidInput = false;
                    break;
                case "7":
                case "8":
                case "9":
                    CheckCalcAndPrint(inputValue, 1000);
                    isValidInput = false;
                    break;
                default:
                    Console.WriteLine("There is no such possible score, please try again. Press a key...");
                    Console.ReadKey();
                    Console.Clear();
                    isValidInput = true;
                    break;
            }
        }
        while (isValidInput);
    }

    private static void CheckCalcAndPrint(string input, int multiplier)
    {
        int score = int.Parse(input);
        int total = score * multiplier;
        Console.WriteLine("Entered score = {0}, final score = {1} (bonus = {2})", score, total, total - score);
    }
}