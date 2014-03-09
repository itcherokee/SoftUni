namespace PrimitiveDataTypesAndVariables
{
    using System;

    /// <summary>
    /// Task:   7. Declare two string variables and assign them with “Hello” and “World”. Declare an object variable 
    ///         and assign it with the concatenation of the first two variables (mind adding an interval between). 
    ///         Declare a third string variable and initialize it with the value of the object variable (you should 
    ///         perform type casting).
    /// </summary>
    public class StringsAndObjects
    {
        public static void Main()
        {
            Console.Title = "Casting object to string";
            string hello = "Hello";
            string world = "World";
            object objectHelloWorld = hello + " " + world;
            string stringHelloWorldOne = objectHelloWorld.ToString();
            string stringHelloWorldTwo = (string)objectHelloWorld;
            Console.WriteLine(stringHelloWorldOne + " - by using ToString() method (not exactly casting)");
            Console.WriteLine(stringHelloWorldTwo + " - by using explicit casting \"(string)\"");
            Console.ReadKey();
        }
    }
}