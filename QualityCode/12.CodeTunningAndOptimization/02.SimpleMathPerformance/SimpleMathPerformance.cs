// Task 2:  Write a program to compare the performance of add, subtract, increment, multiply, divide 
//          for int, long, float, double and decimal values.
//
// Note:    In order to reduce as much as possible external impacts on measurement, I have removed 
//          variable declarations and variable assignments as much as possible - working mainly with constants.

namespace SimpleMathPerformance
{
    using System;
    using System.Diagnostics;
    using System.Globalization;

    public class SimpleMathPerformance
    {
        public static void Main()
        {
            const string Int = "int";
            const string Long = "long";
            const string Float = "float";
            const string Double = "double";
            const string Decimal = "decimal";

            const int NumberOneInt = 10000;
            const int NumberTwoInt = 1000;
            const long NumberOneLong = 10000L;
            const long NumberTwoLong = 1000L;
            const float NumberOneFloat = 10000f;
            const float NumberTwoFloat = 1000f;
            const double NumberOneDouble = 10000d;
            const double NumberTwoDouble = 1000d;
            const decimal NumberOneDecimal = 10000m;
            const decimal NumberTwoDecimal = 1000m;

            var timeElapsed = new Stopwatch();

            // test Addition performance
            string operation = "add";
            timeElapsed.Start();
            int resultInt = NumberOneInt + NumberTwoInt;
            timeElapsed.Stop();
            ShowResult(operation, Int, NumberOneInt, NumberTwoInt, resultInt, timeElapsed.Elapsed);

            timeElapsed.Restart();
            long resultLong = NumberOneLong + NumberTwoLong;
            timeElapsed.Stop();
            ShowResult(operation, Long, NumberOneLong, NumberTwoLong, resultLong, timeElapsed.Elapsed);

            timeElapsed.Restart();
            float resultFloat = NumberOneFloat + NumberTwoFloat;
            timeElapsed.Stop();
            ShowResult(operation, Float, (decimal)NumberOneFloat, (decimal)NumberTwoFloat, (decimal)resultFloat, timeElapsed.Elapsed);

            timeElapsed.Restart();
            double resultDouble = NumberOneDouble + NumberTwoDouble;
            timeElapsed.Stop();
            ShowResult(operation, Double, (decimal)NumberOneDouble, (decimal)NumberTwoDouble, (decimal)resultDouble, timeElapsed.Elapsed);

            timeElapsed.Restart();
            decimal resultDecimal = NumberOneDecimal + NumberTwoDecimal;
            timeElapsed.Stop();
            ShowResult(operation, Decimal, NumberOneDecimal, NumberTwoDecimal, resultDecimal, timeElapsed.Elapsed);

            // test Subtract performance
            operation = "subtract";
            timeElapsed.Restart();
            resultInt = NumberOneInt - NumberTwoInt;
            timeElapsed.Stop();
            ShowResult(operation, Int, NumberOneInt, NumberTwoInt, resultInt, timeElapsed.Elapsed);

            timeElapsed.Restart();
            resultLong = NumberOneLong - NumberTwoLong;
            timeElapsed.Stop();
            ShowResult(operation, Long, NumberOneLong, NumberTwoLong, resultLong, timeElapsed.Elapsed);

            timeElapsed.Restart();
            resultFloat = NumberOneFloat - NumberTwoFloat;
            timeElapsed.Stop();
            ShowResult(operation, Float, (decimal)NumberOneFloat, (decimal)NumberTwoFloat, (decimal)resultFloat, timeElapsed.Elapsed);

            timeElapsed.Restart();
            resultDouble = NumberOneDouble - NumberTwoDouble;
            timeElapsed.Stop();
            ShowResult(operation, Double, (decimal)NumberOneDouble, (decimal)NumberTwoDouble, (decimal)resultDouble, timeElapsed.Elapsed);

            timeElapsed.Restart();
            resultDecimal = NumberOneDecimal - NumberTwoDecimal;
            timeElapsed.Stop();
            ShowResult(operation, Decimal, NumberOneDecimal, NumberTwoDecimal, resultDecimal, timeElapsed.Elapsed);

            // test Increment performance
            operation = "increment";
            timeElapsed.Restart();
            resultInt = NumberOneInt + 1;
            timeElapsed.Stop();
            ShowResult(operation, Int, NumberOneInt, 1, resultInt, timeElapsed.Elapsed);

            timeElapsed.Restart();
            resultLong = NumberOneLong + 1;
            timeElapsed.Stop();
            ShowResult(operation, Long, NumberOneLong, 1, resultLong, timeElapsed.Elapsed);

            timeElapsed.Restart();
            resultFloat = NumberOneFloat + 1;
            timeElapsed.Stop();
            ShowResult(operation, Float, (decimal)NumberOneFloat, 1, (decimal)resultFloat, timeElapsed.Elapsed);

            timeElapsed.Restart();
            resultDouble = NumberOneDouble + 1;
            timeElapsed.Stop();
            ShowResult(operation, Double, (decimal)NumberOneDouble, 1, (decimal)resultDouble, timeElapsed.Elapsed);

            timeElapsed.Restart();
            resultDecimal = NumberOneDecimal + 1;
            timeElapsed.Stop();
            ShowResult(operation, Decimal, NumberOneDecimal, 1, resultDecimal, timeElapsed.Elapsed);

            // test Multiply performance
            operation = "multiply";
            timeElapsed.Restart();
            resultInt = NumberOneInt * NumberTwoInt;
            timeElapsed.Stop();
            ShowResult(operation, Int, NumberOneInt, NumberTwoInt, resultInt, timeElapsed.Elapsed);

            timeElapsed.Restart();
            resultLong = NumberOneLong * NumberTwoLong;
            timeElapsed.Stop();
            ShowResult(operation, Long, NumberOneLong, NumberTwoLong, resultLong, timeElapsed.Elapsed);

            timeElapsed.Restart();
            resultFloat = NumberOneFloat * NumberTwoFloat;
            timeElapsed.Stop();
            ShowResult(operation, Float, (decimal)NumberOneFloat, (decimal)NumberTwoFloat, (decimal)resultFloat, timeElapsed.Elapsed);

            timeElapsed.Restart();
            resultDouble = NumberOneDouble * NumberTwoDouble;
            timeElapsed.Stop();
            ShowResult(operation, Double, (decimal)NumberOneDouble, (decimal)NumberTwoDouble, (decimal)resultDouble, timeElapsed.Elapsed);

            timeElapsed.Restart();
            resultDecimal = NumberOneDecimal * NumberTwoDecimal;
            timeElapsed.Stop();
            ShowResult(operation, Decimal, NumberOneDecimal, NumberTwoDecimal, resultDecimal, timeElapsed.Elapsed);

            // test Divide performance
            operation = "divide";
            timeElapsed.Restart();
            resultInt = NumberOneInt / NumberTwoInt;
            timeElapsed.Stop();
            ShowResult(operation, Int, NumberOneInt, NumberTwoInt, resultInt, timeElapsed.Elapsed);

            timeElapsed.Restart();
            resultLong = NumberOneLong / NumberTwoLong;
            timeElapsed.Stop();
            ShowResult(operation, Long, NumberOneLong, NumberTwoLong, resultLong, timeElapsed.Elapsed);

            timeElapsed.Restart();
            resultFloat = NumberOneFloat / NumberTwoFloat;
            timeElapsed.Stop();
            ShowResult(operation, Float, (decimal)NumberOneFloat, (decimal)NumberTwoFloat, (decimal)resultFloat, timeElapsed.Elapsed);

            timeElapsed.Restart();
            resultDouble = NumberOneDouble / NumberTwoDouble;
            timeElapsed.Stop();
            ShowResult(operation, Double, (decimal)NumberOneDouble, (decimal)NumberTwoDouble, (decimal)resultDouble, timeElapsed.Elapsed);

            timeElapsed.Restart();
            resultDecimal = NumberOneDecimal / NumberTwoDecimal;
            timeElapsed.Stop();
            ShowResult(operation, Decimal, NumberOneDecimal, NumberTwoDecimal, resultDecimal, timeElapsed.Elapsed);
        }

        private static void ShowResult(string action, string type, decimal operandOne, decimal operandTwo, decimal result, TimeSpan timeElapsed)
        {
            string command;
            switch (action)
            {
                case "add":
                    command = "+";
                    break;
                case "subtract":
                    command = "-";
                    break;
                case "multiply":
                    command = "*";
                    break;
                case "divide":
                    command = "/";
                    break;
                case "increment":
                    command = "++";
                    break;
                default:
                    throw new ArgumentException("Invalid action has been specified!");
            }

            Console.WriteLine("({0})({1,-7}) {2} {0} {3} = {4} [time elapsed: {5}]", command, type, operandOne,
                operandTwo != 1 ? operandTwo.ToString(CultureInfo.InvariantCulture) : string.Empty, result, timeElapsed);
        }
    }
}
