using System.Data.Entity.Infrastructure;

namespace BunniesCraft.Data.Repositories
{
    using System.Data.Entity;

    using Model;

    public interface IBunniesDbContext
    {
        IDbSet<Bunny> Bunnies { get; set; }

        IDbSet<AirCraft> AirCrafts { get; set; }

        void SaveChanges();

        IDbSet<TEntity> Set<TEntity>() where TEntity : class;

        DbEntityEntry<TEntity> Entry<TEntity>(TEntity entity) where TEntity : class;
    }
}