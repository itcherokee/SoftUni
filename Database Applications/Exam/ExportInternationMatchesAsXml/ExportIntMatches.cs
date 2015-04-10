namespace InternationMatches
{
    using System.Globalization;
    using System.Linq;
    using System.Threading;
    using System.Xml.Linq;
    using FootballMapping;

    public class ExportIntMatches
    {
        public static void Main()
        {
            using (var context = new FootballEntities())
            {
                var matches = context.InternationalMatches
                    .OrderBy(im => im.MatchDate)
                    .ThenBy(im => im.HostCountry.CountryName)
                    .ThenBy(im => im.GuestCountry.CountryName)
                    .Select(im => new
                    {
                        im.HomeCountryCode,
                        HomeCountry = im.HostCountry.CountryName,
                        GuestCountryCode = im.AwayCountryCode,
                        GuestCountry = im.GuestCountry.CountryName,
                        HostScore = im.HomeGoals,
                        GuestScore = im.AwayGoals,
                        im.League.LeagueName,
                        DateTime = im.MatchDate
                    });

                var xmlContent = new XElement("matches");
                foreach (var match in matches)
                {
                    var matchElement =
                        new XElement("match",
                            new XElement("home-country", new XAttribute("code", match.HomeCountryCode), match.HomeCountry),
                            new XElement("away-country", new XAttribute("code", match.GuestCountryCode), match.GuestCountry)
                             );

                    if (match.GuestScore != null || match.HostScore != null)
                    {
                        matchElement.Add(new XElement("score", match.HostScore, "-", match.GuestScore));
                    }

                    if (match.LeagueName != null)
                    {
                        matchElement.Add(new XElement("league", match.LeagueName));
                    }

                    if (match.DateTime != null)
                    {
                        var hasTime = match.DateTime.Value.TimeOfDay.TotalSeconds > 0;
                        Thread.CurrentThread.CurrentCulture = new CultureInfo("en-US");
                        matchElement.Add(hasTime
                            ? new XAttribute("date-time", match.DateTime.Value.ToString("dd-MMM-yyyy hh:mm"))
                            : new XAttribute("date", match.DateTime.Value.ToString("dd-MMM-yyyy")));
                    }

                    xmlContent.Add(matchElement);
                }

                var xmlDoc = new XDocument();
                xmlDoc.Add(xmlContent);
                xmlDoc.Save("international-matches.xml");
            }
        }
    }
}
;