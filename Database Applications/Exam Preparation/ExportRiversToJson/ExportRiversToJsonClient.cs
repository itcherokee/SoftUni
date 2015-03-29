using System.IO;

namespace ExportRiversToJson
{
    using System;
    using System.Linq;
    using EntityFrameworkMapping;
    using System.Web.Script.Serialization;

    public class ExportRiversToJsonClient
    {
        public static void Main()
        {
            // Problem 2.	Export the Rivers as JSON
            // Write a C# application based on your EF data model for exporting all rivers along with their countries
            // in the following JSON format: 

            // [{ "riverName": "Nile", "riverLength": 6650, "countries": ["Burundi","Democratic Republic of the Congo","Egypt","Eritrea","Ethiopia","Kenya","Rwanda","South Sudan","Sudan","Tanzania","Uganda"] },
            // { "riverName": "Amazon", "riverLength": 6400, "countries": ["Bolivia","Brazil","Colombia","Ecuador","Guyana","Peru","Venezuela"] },
            // { "riverName": "Yangtze", "riverLength": 6300, "countries":["China"] },
            //  …
            // ]

            // 1. Write the output in a JSON file named rivers.json. Include in the output the rivers with no countries 
            // (if any). The JSON file code formatting is not important. - 8 score
            // 2. Order the rivers by length (from the longest) and the countries for each river alphabetically. - 3 score
            // 3. For better performance, ensure your program executes a single DB query and retrieves from the database 
            // only the required data (without unneeded rows and columns).

            using (var context = new GeographyEntities())
            {
                var rivers = context.Rivers
                    .OrderByDescending(r=>r.Length)
                    .Select(r => new
                    {
                        riverName = r.RiverName,
                        riverLength = r.Length,
                        countries = r.Countries
                        .OrderBy(c=>c.CountryName)
                        .Select(c => c.CountryName)
                    });

                var json = new JavaScriptSerializer().Serialize(rivers);
                File.WriteAllText("rivers.json", json);
            }
        }
    }
}
