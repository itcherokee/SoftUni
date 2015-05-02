namespace NewsRestService.Data
{
    using System.Data.Entity;

    using Migrations;
    using Model;

    public class NewsDbContext : DbContext, INewsDbContext
    {
        public NewsDbContext()
            : base("NewsRestConnection")
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<NewsDbContext, Configuration>());
        }

        public IDbSet<News> News { get; set; }

        public IDbSet<T> Set<T>() where T : class
        {
            return base.Set<T>();
        }
    }
}
