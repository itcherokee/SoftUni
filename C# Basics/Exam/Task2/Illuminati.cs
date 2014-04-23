using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task2
{
    class Illuminati
    {
        static void Main(string[] args)
        {
            const byte VowelA = 65;
            const byte VowelE = 69;
            const byte VowelI = 73;
            const byte VowelO = 79;
            const byte VowelU = 85;
            string message = Console.ReadLine();
            int sum = 0;
            int count = 0;
            for (int i = 0; i < message.Length; i++)
            {
                if (message[i].Equals('a') || message[i].Equals('A'))
                {
                    sum += VowelA;
                    count++;
                }
                else if (message[i].Equals('e') || message[i].Equals('E'))
                {
                    sum += VowelE;
                    count++;
                }
                else if (message[i].Equals('i') || message[i].Equals('I'))
                {
                    sum += VowelI;
                    count++;
                }
                else if (message[i].Equals('o') || message[i].Equals('O'))
                {
                    sum += VowelO;
                    count++;
                }
                else if (message[i].Equals('u') || message[i].Equals('U'))
                {
                    sum += VowelU;
                    count++;
                }
            }

            Console.WriteLine(count);
            Console.WriteLine(sum);
        }
    }
}
