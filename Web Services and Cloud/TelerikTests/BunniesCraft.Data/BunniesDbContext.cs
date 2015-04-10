namespace BunniesCraft.Data
{
    using System.Data.Entity;
    using Migrations;
    using Repositories;

    using Model;

    public class BunniesDbContext : DbContext, IBunniesDbContext
    {
        public BunniesDbContext()
            : base("BunniesCraft")
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<BunniesDbContext, Configuration>());
        }

        public virtual IDbSet<Bunny> Bunnies { get; set; }

        public virtual IDbSet<AirCraft> AirCrafts { get; set; }

        public void SaveChanges()
        {
            base.SaveChanges();
        }

        public IDbSet<TEntity> Set<TEntity>() where TEntity : class
        {
            return base.Set<TEntity>();
        }
    }
}
