// Task 5:  ** Write a class BitArray that holds a bit sequence of integer numbers. It should support
//          bit arrays of size between 1 and 100 000 bits. The number of bits is assigned when initializing 
//          the object. The class should support bit indexation (accessing and changing any bit at any 
//          position – e.g. num[2] = 0, num[867] = 1, etc.)
//              • Override ToString() to print the number in decimal format. For example, we can create 
//              a BitArray object num with 8 bits (bits are 0 by default). We change the bit at 
//              position 7 to have a value of 1 (num[7] = 1) and print it on the console. The result is 128.

namespace Bit
{
    using System;

    public class BitArrayExec
    {
        public static void Main()
        {
            var number = new BitArray(9);
            number[8] = 1;
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("Numbers of bits: {0}; array[8]=1 is number: ", number.NumberOfBits);
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(number);

            number = new BitArray(1000);
            number[999] = 1;
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("\nNumbers of bits: {0}; array[999]=1 is number: ", number.NumberOfBits);
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(number);

            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("\nPress a key to see the 100000-bit number with highest bit set:");
            Console.ReadKey();

            number = new BitArray(100000);
            number[99999] = 1;
            Console.Write("\nNumbers of bits: {0}; array[99999]=1 is number: ", number.NumberOfBits);
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(number);
            Console.ForegroundColor = ConsoleColor.White;
            Console.ReadKey();
        }
    }
}
