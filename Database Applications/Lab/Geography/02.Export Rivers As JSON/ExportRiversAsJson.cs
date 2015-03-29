namespace RiversAsJson
{
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Web.Script.Serialization;

    using ListCountries;

    public class ExportRiversAsJson
    {
        public static void Main()
        {
            using (var context = new GeographyEntities())
            {
                var query = context.Rivers
                    .OrderByDescending(o => o.Length)
                    .Select(r => new
                {
                    Name = r.RiverName, r.Length,
                    Countries = r.Countries
                    .OrderBy(o => o.CountryName)
                    .Select(c => c.CountryName)
                });
//
//                foreach (var river in query)
//                {
//                    Console.WriteLine(river.Name + " - " + river.Length + " [ " + string.Join(", ",river.Countries) + " ]");
//                    
//                }

                var serializer = new JavaScriptSerializer();
                var json = serializer.Serialize(query);
                File.WriteAllText(@".\rivers.json", json, Encoding.UTF8);
            }
        }
    }
}
