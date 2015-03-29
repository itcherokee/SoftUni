using System;
using System.Linq;
using System.Xml;

namespace MonasteriesByCountry
{
    using ListCountries;

    public class ExportMonasteriesByCountry
    {
        public static void Main()
        {
            using (var context = new GeographyEntities())
            {
                var query = context
                    .Countries.OrderBy(c => c.CountryName)
                    .Where(c=>c.Monasteries.Any())
                    .Select(c => new
                    {
                        c.CountryName,
                        Monasteries = c.Monasteries.OrderBy(m=>m.Name).Select(m=>m.Name)
                    });

                foreach (var country in query)
                {
                    Console.WriteLine(country.CountryName + ":\n\t- " + string.Join("\n\t- ", country.Monasteries));
                }

                XmlDocument doc = new XmlDocument();
            }
        }
    }
}
