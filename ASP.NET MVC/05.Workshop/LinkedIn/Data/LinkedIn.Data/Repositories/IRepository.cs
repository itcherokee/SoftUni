namespace LinkedIn.Data.Repositories
{
    using System.Data.Entity;
    using System.Linq;

    public interface IRepository<T> where T : class
    {
        IDbSet<T> Set { get; }

        IQueryable<T> All();

        T Find(object id);

        void Add(T entity);

        void Update(T entity);

        void Delete(T entity);

        T Delete(object id);
    }
}
