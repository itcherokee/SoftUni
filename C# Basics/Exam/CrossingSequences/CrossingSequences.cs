using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrossingSequences
{
    class CrossingSequences
    {
        static void Main(string[] args)
        {
            int numberOne = int.Parse(Console.ReadLine());
            int numberTwo = int.Parse(Console.ReadLine());
            int numberThree = int.Parse(Console.ReadLine());
            int numberSpiral = int.Parse(Console.ReadLine());
            int spiralStep = int.Parse(Console.ReadLine());
            int currentNumber = numberSpiral;
            bool isFound = false;
            int[] tribonacciSequence = CalcTribonacci(numberOne, numberTwo, numberThree);
            if (!tribonacciSequence.Contains(currentNumber))
            {
                int skip = 0;
                int stepCounter = 0;
                int countsPerOffset = 0;
                int offset = 0;
                bool check = true;
                while (!isFound && currentNumber <= 2000000)
                {
                    currentNumber = currentNumber + spiralStep;

                    if (check)
                    {
                        stepCounter++;
                        countsPerOffset++;
                        if (tribonacciSequence.Contains(currentNumber))
                        {
                            isFound = true;
                            break;
                        }

                        if (countsPerOffset == 2)
                        {
                            offset++;
                            stepCounter = 0;
                            countsPerOffset = 0;
                        }

                        skip = offset;
                    }
                    else
                    {
                        skip--;
                    }

                    check = skip <= 0;
                }
            }
            else
            {
                isFound = true;
            }

            if (isFound)
            {
                Console.WriteLine(currentNumber);
            }
            else
            {
                Console.WriteLine("No");
            }
        }

        private static int[] CalcTribonacci(int one, int two, int three)
        {
            var numbers = new List<int>(new[] { one, two, three });
            int nextNumber = 0;

            int counter = 3;
            while (nextNumber <= 2000000)
            {
                nextNumber = numbers[counter - 1] + numbers[counter - 2] + numbers[counter - 3];
                if (nextNumber <= 2000000)
                {
                    numbers.Add(nextNumber);
                }

                counter++;
            }


            return numbers.ToArray();
        }
    }
}
