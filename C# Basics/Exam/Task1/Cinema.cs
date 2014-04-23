using System;

namespace Task1
{
    class Cinema
    {
        static void Main(string[] args)
        {
            string projectionType = Console.ReadLine();
            byte rows = byte.Parse(Console.ReadLine());
            byte columns = byte.Parse(Console.ReadLine());
            int seats = rows * columns;
            decimal income = 0m;
            switch (projectionType)
            {
                case "Premiere":
                    income = seats * 12m;
                    break;
                case "Normal":
                    income = seats * 7.5m;
                    break;
                case "Discount":
                    income = seats * 5m;
                    break;
            }

            Console.WriteLine("{0:F2} leva", income);
        }
    }
}
