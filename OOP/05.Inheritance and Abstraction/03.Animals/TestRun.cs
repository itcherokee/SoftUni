// Task 3:  Create an abstract class Animal holding name, age and gender.
//          • Create a hierarchy with classes Dog, Frog, Cat, Kitten and Tomcat. Dogs, frogs and cats are animals. 
//            Kittens are female cats and Tomcats are male cats. Define useful constructors and methods. 
//          • Define an interface ISound which implements the method ProduceSound(). All animals should implement 
//            this interface. The ProduceSound() method should produce a specific sound according to the animal 
//            (e.g. the dog should bark).
//          • Create arrays of different kinds of animals and calculate the average age of each kind of animal using LINQ.

namespace Animals
{
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using System.Linq;

    public class TestRun
    {
        public static void Main()
        {
            // Create couple of different Animals and add to array
            var animals = new Animal[9]
            { 
                new Dog("Sharo", 10, Gender.Male),
                new Dog("Baro", 4, Gender.Male),
                new Dog("Ceca", 5, Gender.Female),
                new Dog("Tochka", 7,  Gender.Female),
                new Frog("Kvaki", 54, Gender.Female),
                new Frog("To", 9, Gender.Male),
                new Kitten("Tomka", 2),
                new Tomcat("Tom", 10),
                new Tomcat("Slon", 12)
            };

            // Print the average age per Animal type using LINQ 
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("Average age calculation using method based on LINQ");
            Console.ForegroundColor = ConsoleColor.White;
            foreach (var animal in AverageAgeLinq(animals))
            {
                Console.WriteLine("Average age for {0}s is: {1}", animal.Key, animal.Value);
            }

            // Print the average age per Animal type using Extension methods
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("Average age calculation using method based on extension methods");
            Console.ForegroundColor = ConsoleColor.White;
            foreach (var animal in AverageAgeExt(animals))
            {
                Console.WriteLine("Average age for {0}s is: {1}", animal.Key, animal.Value);
            }

            // Print the average age per Animal type using normal C# language methods
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("Average age calculation using method based on C# language methods/operators");
            Console.ForegroundColor = ConsoleColor.White;
            foreach (var animal in AverageAge(animals))
            {
                Console.WriteLine("Average age for {0}s is: {1}", animal.Key, animal.Value);
            }
        }

        /// <summary>
        /// Calculates average age of each animal type using LINQ.
        /// </summary>
        /// <param name="animals">List with Animal objects.</param>
        /// <returns>A Disctionary instance containing name of the animal class with average age of elements within.</returns>
        private static Dictionary<string, double> AverageAgeLinq(params Animal[] animals)
        {
            var queryAnimals = from animal in animals
                               group animal by animal.GetType() into animalType
                               select new
                                       {
                                           AnimalType = animalType.Key.Name,
                                           AverageAge = animalType.Average(x => x.Age),
                                       };

            return queryAnimals.ToDictionary(
                key => key.AnimalType.ToString(CultureInfo.InvariantCulture), age => age.AverageAge);
        }

        /// <summary>
        /// Calculates average age of each animal type using Extension methods.
        /// </summary>
        /// <param name="animals">List with Animal objects.</param>
        /// <returns>A Disctionary instance containing name of the animal class with average age of elements within.</returns>
        private static Dictionary<string, double> AverageAgeExt(params Animal[] animals)
        {
            var queryAnimals = animals
                            .GroupBy(animal => animal.GetType())
                            .Select(animalType => new
                                                     {
                                                         AnimalType = animalType.Key.Name,
                                                         AverageAge = animalType.Average(x => x.Age),
                                                     });

            return queryAnimals.ToDictionary(
                key => key.AnimalType.ToString(CultureInfo.InvariantCulture), age => age.AverageAge);
        }

        /// <summary>
        /// Calculates average age of each animal type using normal C# language methods/operators.
        /// </summary>
        /// <param name="list">List with Animal objects</param>
        /// <returns>A Disctionary instance containing name of the animal class with average age of elements within.</returns>
        private static Dictionary<string, double> AverageAge(params Animal[] list)
        {
            // grouping different types of Animals with sums of their ages
            var result = new Dictionary<Type, AgesCalc>();
            var ageCalculation = new AgesCalc();
            foreach (var animal in list)
            {
                Type current = animal.GetType();
                if (!result.ContainsKey(current))
                {
                    ageCalculation.Sum = animal.Age;
                    ageCalculation.Count = 1;
                    result.Add(current, ageCalculation);
                }
                else
                {
                    ageCalculation.Sum = result[current].Sum + animal.Age;
                    ageCalculation.Count = result[current].Count + 1;
                    result[current] = ageCalculation;
                }
            }

            return result.ToDictionary(item => item.Key.Name, item => item.Value.Sum / item.Value.Count);
        }

        // used for calculations in Average method
        private struct AgesCalc
        {
            internal double Sum;
            internal int Count;
        }
    }
}
