using System;
using System.Xml.Linq;

namespace MonasteriesByCountryToXml
{
    using EntityFrameworkMapping;
    using System.Linq;

    public class ExportMonasteries
    {
        public static void Main()
        {
            // Problem 3.	Export Monasteries by Country as XML
            // Write a C# application based on your EF data model for exporting all monasteries by country in a XML file 
            // named monasteries.xml in the following XML format:
            // 
            // <?xml version="1.0" encoding="utf-8"?>
            // <monasteries>
            //  <country name="Bhutan">
            //   <monastery>Taktsang Palphug Monastery</monastery>
            //  </country>
            //  <country name="Bulgaria">
            //   <monastery>Bachkovo Monastery “Virgin Mary”</monastery>
            //   <monastery>Rila Monastery “St. Ivan of Rila”</monastery>
            //   <monastery>Troyan Monastery “Holy Mother's Assumption”</monastery>
            //  </country>
            // …
            // </monasteries>
            // 
            // 1. Exclude all countries with no monasteries. Use an XML parser by choice. - 8 score
            // 2. Order the countries alphabetically and the monasteries in each country also alphabetically. - 3 score
            // 3. For better performance, ensure your program executes a single DB query and retrieves from the database 
            // only the required data (without unneeded rows and columns). - 4 score

            using (var context = new GeographyEntities())
            {
                var countries = context.Countries
                    .Where(c => c.Monasteries.Any())
                    .OrderBy(c => c.CountryName)
                    .Select(c => new
                            {
                                name = c.CountryName,
                                monasteries = c.Monasteries
                                    .OrderBy(m => m.Name)
                                    .Select(m => m.Name)
                            });

                var xmlDoc = new XElement("monasteries");
                foreach (var country in countries)
                {
                    xmlDoc.Add(
                        new XElement("country",
                            new XAttribute("name", country.name),
                                from m in country.monasteries
                                select new XElement("monastery", m)));
                }

                xmlDoc.Save("monasteries.xml");
            }
        }
    }
}
