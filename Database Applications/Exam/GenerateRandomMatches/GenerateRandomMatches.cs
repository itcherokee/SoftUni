using System;
using System.Linq;
using System.Xml.Linq;
using FootballMapping;

namespace GenerateRandomMatches
{
    public class GenerateRandomMatches
    {
        public static void Main()
        {
            var xmlDoc = XElement.Load("../../generate-matches.xml");

            using (var context = new FootballEntities())
            {
                var counter = 1;
                var generateCount = 10;
                var maxGoals = 5;
                var startDate = new DateTime(2000, 01, 01);
                var endDate = new DateTime(2015, 12, 31);
                string leagueName = null;
                foreach (var generate in xmlDoc.Elements())
                {
                    Console.WriteLine("Processing request #{0} ...", counter++);
                    if (generate.Attribute("generate-count") != null)
                    {
                        generateCount = int.Parse(generate.Attribute("generate-count").Value);
                    }

                    if (generate.Attribute("max-goals") != null)
                    {
                        maxGoals = int.Parse(generate.Attribute("max-goals").Value);
                    }

                    if (generate.Attribute("start-date") != null)
                    {
                        startDate = DateTime.Parse(generate.Element("start-date").Value);
                    }

                    if (generate.Element("end-date") != null)
                    {
                        endDate = DateTime.Parse(generate.Element("end-date").Value);
                    }

                    if (generate.Element("league") != null)
                    {
                        leagueName = generate.Element("league").Value;
                    }

                    //context.TeamMatches.Add(new TeamMatch{ })
                }

                context.SaveChanges();
            }
        }
    }
}
