namespace DistanceCalculatorSoapClient
{
    using System;
    using ServiceCalcDIstance;

    public class DistanceCaluculatorClient
    {
        public static void Main()
        {
            var service = new CalcDistanceClient();
            var pointOne = new Point { X = 2, Y = 3 };
            var pointTwo = new Point { X = -2, Y = -3 };
            double distance = service.CalculateDistance(pointOne, pointTwo);

            Console.WriteLine(
                "Distance between p({0},{1}) & p({2},{3}) is {4}",
                pointOne.X,
                pointOne.Y,
                pointTwo.X,
                pointTwo.Y,
                distance);
        }
    }
}
