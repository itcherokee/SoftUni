// Task 2:  Add exception handling (where missing) and refactor all incorrect error handling in the code 
//          from the "Exceptions-Homework" project to follow the best practices for using exceptions.

namespace ExceptionsHomework
{
    using System;
    using System.Collections.Generic;

    public class ExceptionsHomework
    {
        public static void Main()
        {
            try
            {
                var text = Utils.Subsequence("Hello!".ToCharArray(), 2, 3);
                Console.WriteLine(text);

                var halfOfArrayContent = Utils.Subsequence(new[] { -1, 3, 2, 1 }, 0, 2);
                Console.WriteLine(string.Join(" ", halfOfArrayContent));

                var fullArrayContent = Utils.Subsequence(new[] { -1, 3, 2, 1 }, 0, 4);
                Console.WriteLine(string.Join(" ", fullArrayContent));

                var emptyarr = Utils.Subsequence(new[] { -1, 3, 2, 1 }, 0, 0);
                Console.WriteLine(string.Join(" ", emptyarr));

                Console.WriteLine(Utils.ExtractEnding("I love C#", 2));
                Console.WriteLine(Utils.ExtractEnding("Nakov", 4));

                // uncomment below two lines to enable exception throw

                // Console.WriteLine(Utils.ExtractEnding("beer", 4));
                // Console.WriteLine(Utils.ExtractEnding("Hi", 100));

                int primeNumber = 23;
                bool isPrimeNumber = Utils.CheckPrime(primeNumber);
                Console.WriteLine("{0} is" + (isPrimeNumber ? " " : " not ") + "prime.", primeNumber);

                primeNumber = 33;
                isPrimeNumber = Utils.CheckPrime(primeNumber);
                Console.WriteLine("{0} is" + (isPrimeNumber ? " " : " not ") + "prime.", primeNumber);

                primeNumber = -1;
                isPrimeNumber = Utils.CheckPrime(primeNumber);
                Console.WriteLine("{0} is" + (isPrimeNumber ? " " : " not ") + "prime.", primeNumber);

                var peterExams = new List<Exam>()
                {
                    new SimpleMathExam(2), 
                    new CSharpExam(55), 
                    new CSharpExam(100), 
                    new SimpleMathExam(1), 
                    new CSharpExam(0)
                };

                var peter = new Student("Peter", "Petrov", peterExams);
                double peterAverageResult = peter.CalcAverageExamResultInPercents();
                Console.WriteLine("Average results = {0:p0}", peterAverageResult);
            }
            catch (ArgumentNullException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (ArgumentOutOfRangeException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}