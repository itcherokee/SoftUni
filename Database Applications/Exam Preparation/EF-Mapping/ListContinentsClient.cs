namespace EntityFrameworkMapping
{
    using System;
    using System.Linq;
    
    public class ListContinentsClient
    {
        public static void Main()
        {
            // Problem 1.	Entity Framework Mappings (Database First)
            // Create an Entity Framework (EF) data model of the existing database (map the database tables to C# classes).
            // Use the "database first" model in EF. To test your EF data model, list all continent names.

            using (var context = new GeographyEntities())
            {
                var continentsNames = context.Continents.Select(c => c.ContinentName);
                foreach (var continentName in continentsNames)
                {
                    Console.WriteLine(continentName);
                }
            }

            using (var context = new GeographyEntities())
            {
                var continents = context.Continents;
                foreach (var continent in continents)
                {
                    Console.WriteLine(continent.ContinentName);
                }
            }
        }
    }
}
