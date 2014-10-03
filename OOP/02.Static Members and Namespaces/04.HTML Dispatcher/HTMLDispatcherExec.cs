// Task 4:  * Write a class ElementBuilder that creates HTML elements....

namespace HTML
{
    using System;

    public class HTMLDispatcherExec
    {
        public static void Main()
        {
            var div = new ElementBuilder("div");
            div.AddAttribute("id", "page");
            div.AddAttribute("class", "big");
            div.AddContent("<p>Hello</p>");
            Console.WriteLine(div * 2);

            Console.WriteLine(HTMLDispatcher.CreateImage("../car.png", "Sport car", "Sport car"));
            Console.WriteLine(HTMLDispatcher.CreateInput("button", "Submit", "Submit"));
            Console.WriteLine(HTMLDispatcher.CreateURL("http://softuni.bg", "SoftUni link", "Software University"));
            Console.ReadKey();
        }
    }
}
