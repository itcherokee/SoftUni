namespace ImportTeamsAndLeagues
{
    using System;
    using System.Linq;
    using System.Xml.Linq;
    using FootballMapping;


    public class ImportFromXml
    {
        public static void Main()
        {
            var xmlDoc = XElement.Load("../../leagues-and-teams.xml");
            using (var context = new FootballEntities())
            {
                var counter = 1;
                foreach (var league in xmlDoc.Elements())
                {
                    Console.WriteLine("Processing league #{0} ...", counter++);
                    var leagueInXml = league.Element("league-name");
                    bool leagueExistsInQuery = leagueInXml != null;
                    if (leagueInXml != null)
                    {
                        var leagueInDb = context.Leagues.FirstOrDefault(l => l.LeagueName == leagueInXml.Value);
                        if (leagueInDb == null)
                        {
                            var newLeague = new League { LeagueName = league.Element("league-name").Value };
                            context.Leagues.Add(newLeague);
                            Console.WriteLine("Created league: {0}", newLeague.LeagueName);
                            context.SaveChanges();
                        }
                        else
                        {
                            Console.WriteLine("Existing league: {0}", leagueInDb.LeagueName);
                        }
                    }

                    var teamsInXml = league.Element("teams");
                    bool teamsExistsInQuery = teamsInXml != null;

                    if (teamsInXml != null && teamsInXml.Descendants().Any())
                    {
                        foreach (var team in teamsInXml.Descendants())
                        {
                            string teamNameInXml = team.Attribute("name").Value;
                            string teamCountryInXml = null;
                            if (team.Attribute("country") != null)
                            {
                                teamCountryInXml = team.Attribute("country").Value;
                            }

                            // check does team exists
                            var teamInDb = context.Teams.FirstOrDefault(t => t.TeamName == teamNameInXml);
                            if (teamInDb != null)
                            {
                                if ((teamInDb.Country != null) && teamInDb.Country.CountryName == (teamCountryInXml ?? ""))
                                {
                                    // team exists 
                                    Console.WriteLine(
                                        "Existing team: {0} ({1})",
                                        teamNameInXml,
                                        teamCountryInXml ?? "no country");

                                    // Check and eventually add team to league if necessary
                                    if (leagueExistsInQuery && teamsExistsInQuery)
                                    {
                                        var teamLeague =
                                            teamInDb.Leagues.FirstOrDefault(l => l.LeagueName == leagueInXml.Value);
                                        if (teamLeague != null)
                                        {
                                            Console.WriteLine("Existing team in league: {0} belongs to {1}",
                                                teamNameInXml,
                                                teamLeague.LeagueName);
                                        }
                                        else
                                        {
                                            teamInDb.Leagues.Add(teamLeague);
                                            context.SaveChanges();
                                            Console.WriteLine("Added team to league: {0} to league {1}",
                                                teamNameInXml, leagueInXml.Value);
                                        }
                                    }
                                }
                            }
                            else
                            {
                                // not exisiting 
                                var newTeam = new Team { TeamName = teamNameInXml };
                                if (teamCountryInXml != null)
                                {
                                    // get country code
                                    var teamCountryCode = context.Countries
                                        .Where(c => c.CountryName == teamCountryInXml)
                                        .Select(c => c.CountryCode).FirstOrDefault();
                                    if (teamCountryCode != null)
                                    {
                                        newTeam.CountryCode = teamCountryCode;
                                    }
                                }

                                context.Teams.Add(newTeam);
                                context.SaveChanges();
                                Console.WriteLine(
                                    "Created team: {0} ({1})",
                                    teamNameInXml,
                                    teamCountryInXml ?? "no country");

                                // Just add new team to League
                                if (leagueExistsInQuery && teamsExistsInQuery)
                                {
                                    var teamLeague =
                                        context.Leagues.FirstOrDefault(l => l.LeagueName == leagueInXml.Value);

                                    newTeam.Leagues.Add(teamLeague);
                                    context.SaveChanges();
                                    Console.WriteLine("Added team to league: {0} to league {1}",
                                        teamNameInXml, leagueInXml.Value);
                                }
                            }
                        }
                    }
                }

                context.SaveChanges();
            }
        }

    }
}
