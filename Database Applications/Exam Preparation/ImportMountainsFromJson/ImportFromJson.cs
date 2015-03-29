using System;
using System.IO;
using System.Linq;
using EFCodeFirst.Data;
using EFCodeFirst.Model;
using ImportMountainsFromJson.ModelDto;

namespace ImportMountainsFromJson
{
    using System.Web.Script.Serialization;

    public class ImportFromJson
    {
        public static void Main()
        {
            var ser = new JavaScriptSerializer();
            var importedDto = ser.Deserialize<MountainDto[]>(File.ReadAllText("../../mountains.json"));
            foreach (var singleDto in importedDto)
            {
                try
                {
                    using (var context = new MountainsContext())
                    {
                        // check for mountainName
                        if (singleDto.MountainName == null)
                        {
                            throw new ArgumentException("Missing mountain name");
                        }

                        var mountain = new Mountain() { Name = singleDto.MountainName };
                        context.Mountains.Add(mountain);

                        // if there is/are peaks check:
                        if (singleDto.Peaks.Any())
                        {
                            foreach (var peakDto in singleDto.Peaks)
                            {
                                // check for peakName
                                if (peakDto.PeakName == null)
                                {
                                    throw new ArgumentException("Missing peak name");
                                }

                                // check for elevation
                                if (peakDto.Elevation == null)
                                {
                                    throw new ArgumentException("Missing peak elevation");
                                }

                                var peak = new Peak { Name = peakDto.PeakName, Elevation = peakDto.Elevation.Value };
                                mountain.Peaks.Add(peak);
                            }
                        }

                        if (singleDto.Countries.Any())
                        {
                            foreach (var countryDto in singleDto.Countries)
                            {

                                var countryCode = context.Countries.Where(c => c.Name == countryDto).Select(c => c.Code).FirstOrDefault()
                                    ?? countryDto.ToUpper().Take(2).ToString();
                                //                            if (countryFromDb != null)
                                //                            {
                                //                                country.Code = countryFromDb.Code;
                                //                            }
                                //                            else
                                //                            {
                                //                                country.Code = ;
                                //                            }

                                var country = new Country { Name = countryDto, Code = countryCode };
                                mountain.Countries.Add(country);
                            }
                        }

                        Console.WriteLine("Mountain {0} imported", mountain.Name);
                        context.SaveChanges();
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine("Error: {0}", e.Message);
                }
            }
            Console.WriteLine();
        }
    }
}
