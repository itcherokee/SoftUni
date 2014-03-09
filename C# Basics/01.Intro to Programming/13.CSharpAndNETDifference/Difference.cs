namespace IntroToProgramming
{
    using System;
    using System.Text;

    // Task 13: Describe the difference between C# and .NET Framework in 2-3 sentences. 
    public class DifferenceCSharpAndNet
    {
        public static void Main()
        {
            const string TopicDifference = "Не може да става въпрос за сравнение между двете, защото .NET Framework е цялостна платформа за програмни решения, "
                                           + "докато C# е език за програмиране, част от .NET Framework платформата (заедно с други включени от Microsoft - F#, VB.NET, C++). Сам по себе си C# използва библиотеките включени в .NET "
                                           + "и може да се каже, че не е в състояние да съществува и работи без наличието на NET Framework-а.\r\n";

            Console.SetWindowSize(80, 35);
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("Разлика между C# и .NET Framework");
            Console.WriteLine("---------------------");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Сравнение: ");
            PrintLines(TopicDifference);
            Console.WriteLine();
            Console.ReadKey();
        }

        private static void PrintLines(string content)
        {
            Console.ForegroundColor = ConsoleColor.White;
            const int MaxCharsPerLine = 60;
            var lineWithWords = new StringBuilder();
            string[] topic = content.Split(' ');
            for (int index = 0; index < topic.Length; index++)
            {
                lineWithWords.Append(topic[index]);
                lineWithWords.Append(" ");
                if ((lineWithWords.Length > MaxCharsPerLine) || (index == topic.Length - 1))
                {
                    Console.WriteLine(lineWithWords);
                    lineWithWords.Clear();
                }
            }

            Console.ForegroundColor = ConsoleColor.Green;
        }
    } 
}