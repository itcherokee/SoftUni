namespace PrimitiveDataTypesAndVariables
{
    using System;
    using System.Text;

    /// <summary>
    /// Task:   9. Write a program that prints an isosceles triangle of 9 copyright symbols ©. 
    ///         Note that the © symbol may be displayed incorrectly at the console so you may need to change the 
    ///         console character encoding to UTF-8 and assign a Unicode-friendly font in the console. Note also, 
    ///         that under old versions of Windows the © symbol may still be displayed incorrectly, regardless of 
    ///         how much effort you put to fix it
    /// </summary>
    public class Triangle
    {
        public static void Main()
        {
            Console.Title = "Print isosceles triangle with 9 copyright symbols";
            char copyRight = '\u00a9';
            Console.OutputEncoding = Encoding.UTF8;
            Console.WriteLine("{0,4}", copyRight);
            Console.WriteLine("{0,3}{0,2}", copyRight);
            Console.WriteLine("{0,2}{0,4}", copyRight);
            Console.WriteLine("{0,-2}{0,-2}{0,-2}{0,-2}", copyRight);
            Console.ReadKey();
        }
    }
}