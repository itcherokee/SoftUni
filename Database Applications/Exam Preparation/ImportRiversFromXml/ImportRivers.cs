using System;
using System.Linq;
using System.Xml;
using System.Xml.Linq;

namespace ImportRiversFromXml
{
    using EntityFrameworkMapping;

    public class ImportRivers
    {
        public static void Main()
        {
            // Problem 4.	Import Rivers from XML
            // Write a C# application based on your EF data model for importing into the DB a set of rivers given
            // in the XML file rivers.xml. 
            // The name, length and outflow elements are mandatory. The drainage-area, average-discharge and 
            // countries elements are optional.
            // 1. You should parse the XML and throw an exception in case of incorrect data, e.g. when a required 
            // element is missing or an invalid value is given. The size of the XML file will be less than 10 MB.
            // Use an XML parser by choice. - 8 score
            // 2. You should correctly import the rivers into the DB. - 7 score
            // 3. You should correctly import the countries for each river into the DB. - 5 score

            var xmlDoc = XElement.Load("../../rivers.xml");

            using (var context = new GeographyEntities())
            {
                foreach (var riverNode in xmlDoc.Elements())
                {
                    var river = new River();
                    try
                    {
                        river.RiverName = riverNode.Element("name").Value;
                        river.Length = int.Parse(riverNode.Element("length").Value);
                        river.Outflow = riverNode.Element("outflow").Value;
                        if (riverNode.Element("drainage-area") != null)
                        {
                            river.DrainageArea = int.Parse(riverNode.Element("drainage-area").Value);
                        }

                        if (riverNode.Element("average-discharge") != null)
                        {
                            river.AverageDischarge = int.Parse(riverNode.Element("average-discharge").Value);
                        }

                        if (riverNode.Descendants("country").Any())
                        {
                            foreach (var country in riverNode.Descendants("country"))
                            {
                                Console.WriteLine(country);
                                var countryCode =
                                    context.Countries.First(c => c.CountryName == country.Value);
                                river.Countries.Add(countryCode);
                            }
                        }
                    }
                    catch (NullReferenceException e)
                    {
                        throw new ArgumentNullException("Missing mandatory data in XML file");
                    }
                    catch (FormatException e)
                    {
                        throw new ArgumentException("Data provided in XML file are not in correct format");
                    }

                    context.Rivers.Add(river);
                }

                context.SaveChanges();
            }
        }
    }
}
