// Task 02: Define a class Computer that holds name, several components and price. 
//          The components (processor, graphics card, motherboard, etc.) should be 
//          objects of class Component, which holds name, details (optional) and price.
//              • Define several constructors that take different sets of arguments. 
//                Use proper variable types. Use properties to validate the data. 
//                Throw exceptions when improper data is entered.
//              • Add a method in the Computer class that displays the name, each of 
//                the components' name and price and the total computer price. 
//                The total price is the sum of all components' price. Print the prices 
//                in BGN currency format.
//              • Create several Computer objects, sort them by price, and print them 
//                on the console using the created display method.

namespace PC
{
    using System;
    using System.Collections.Generic;

    public class PcCatalog
    {
        public static void Main()
        {
            var bunchOfPCs = new List<Computer>()
            {
                 new Computer("Future Mark 1000",
                        new List<Component>()
                        {
                            new Component("CPU", 223, "Pentium 18 5GHz"),
                            new Component("HDD", 80, "880TB"),
                            new Component("RAM", 100, "128GB"),
                            new Component("GPU", 1230, "ATI Radeon Quad-Quadra T340 36GB"),
                            new Component("Monitor", 400, "56\" SONY")
                        }),
                new Computer("Future Mark 800",
                        new List<Component>()
                        {
                            new Component("CPU", 200, "Pentium Hexa-Core 1.1GHz"),
                            new Component("HDD", 80, "200TB"),
                            new Component("RAM", 20, "64GB"),
                            new Component("GPU", 20, "Intel HD8000 - 1GB"),
                            new Component("Monitor", 322, "24\" Philips"),
                            new Component("keyboard", 5, "101-key A4Tech"),
                            new Component("Mouse", 1.2m),
                        }),
                new Computer("Old Prychka",
                        new List<Component>()
                        {
                            new Component("CPU", 5, "Pentium 2"),
                            new Component("HDD", 11, "10GB"),
                            new Component("RAM", 21, "2GB"),
                            new Component("GPU", 5.5m, "S3 Trio 1MB"),
                            new Component("Monitor", 19, "14\" DELL"),
                            new Component("Printer", 1000, "3D printer"),
                            new Component("Keyboard", 5, "101-key A4Tech"),
                        }),
                new Computer("Another Old Prychka",
                        new List<Component>()
                        {
                            new Component("CPU", 50, "AMD Athlon"),
                            new Component("HDD", 110, "20GB"),
                            new Component("RAM", 21, "2GB"),
                            new Component("GPU", 55.5m, "GeForce Neshto si"),
                            new Component("Monitor", 19, "14\" DELL"),
                            new Component("Printer", 1000, "3D printer"),
                            new Component("Keyboard", 5, "101-key A4Tech"),
                        })
            };

            bunchOfPCs.Sort((x, y) => y.Price.CompareTo(x.Price));

            Console.WriteLine("All available PCs, sorted by Total Prices:\n");
            for (int i = 0; i < bunchOfPCs.Count; i++)
            {
                Console.WriteLine(bunchOfPCs[i].ToString());
            }

            Console.ReadKey();
        }
    }
}
