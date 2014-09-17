// Task 01: Define a class Laptop that holds the following information about a laptop device: 
//          model, manufacturer, processor, graphics card, battery, battery life in hours, 
//          screen size and price.
//              • Define 2 separate classes (class Laptop holding an instance of class Battery).
//              • Define several constructors that take different sets of arguments (full
//                laptop/battery information or only part of it). Use proper variable types.
//              • All non-numeric data should be mandatory. All numeric fields should have a default value of 0.
//              • Add a method in the Laptop class that displays information about the given instance.
//                (Tip: override ToString());
//              • Use properties to validate the data. String values cannot be empty, and numeric data
//                cannot be negative. Throw exceptions when improper data is entered.

namespace LaptopShop
{
    using System;

    public class LaptopShop
    {
        public static void Main()
        {
            Battery battery = new Battery(130, BatteryType.LiPo);
            Laptop laptop = new Laptop("Galaxy S5", "Samsung", "Snapdragon", "Quadra", battery, 5.5, 800);
            Console.WriteLine(laptop);
            Console.ReadKey();
        }
    }
}
