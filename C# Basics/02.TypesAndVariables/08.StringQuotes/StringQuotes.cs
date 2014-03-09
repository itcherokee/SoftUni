namespace PrimitiveDataTypesAndVariables
{
    using System;

    /// <summary>
    /// Task: "8. Declare two string variables and assign them with following value: 
    /// <<The "use" of quotations causes difficulties.>>
    /// Do the above in two different ways: with and without using quoted strings. 
    /// Print the variables to ensure that their value was correctly defined.
    /// </summary>
    public class StringQuotes
    {
        public static void Main()
        {
            Console.Title = "Quotations causes dificulties.";
            string quotedString = @"The ""use"" of quotations causes difficulties.";
            string nonQuotedString = "The \"use\" of quotations causes difficulties.";
            Console.WriteLine(quotedString);
            Console.WriteLine(nonQuotedString);
            Console.ReadKey();
        }
    }
}