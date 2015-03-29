using NewsDatabase.Model;
using NewsDtabase.Data.Migrations;

namespace NewsDtabase.Data
{
    using System.Data.Entity;

    public class NewsDbContext : DbContext
    {
        public NewsDbContext()
            : base("NewsEntities")
        {
            Database.SetInitializer(new NewsDatabaseInitializer());
        }

        public IDbSet<News> News { get; set; }
    }
}
