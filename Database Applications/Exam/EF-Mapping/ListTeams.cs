namespace FootballMapping
{
    using System;
    using System.Linq;

    public class ListTeams
    {
        public static void Main()
        {
            using (var context = new FootballEntities())
            {
                foreach (var team in context.Teams.ToList())
                {
                    Console.WriteLine("Team name: {0}", team.TeamName);
                }
            }
        }
    }
}
