namespace Game
{
    using System;

    public class WalkInMatrix
    {
        public static void Main()
        {
            Console.Write("Enter a positive number [1..100]: ");
            string input = Console.ReadLine();
            int size = 0;
            while (!int.TryParse(input, out size))
            {
                Console.WriteLine("You haven't entered a valid number!");
                Console.Write("Enter a positive number [1..100]: ");
                input = Console.ReadLine();
            }

            try
            {
                Engine engine = new Engine(size);
                Console.WriteLine(engine.Run());
            }
            catch (ArgumentOutOfRangeException ex)
            {
                Console.WriteLine("You have entered a value out of allowed range");
            }
        }
    }
}
