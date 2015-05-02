namespace NewsRestService.Data
{
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;

    using Model;

    public interface INewsDbContext
    {
        IDbSet<News> News { get; set; }

        int SaveChanges();

        DbEntityEntry<TEntity> Entry<TEntity>(TEntity entity) where TEntity : class;

        IDbSet<T> Set<T>() where T : class;
    }
}