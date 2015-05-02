namespace NewsRestService.Data.Repositories
{
    using System.Linq;

    public interface IRepository<T> where T : class
    {
        IQueryable<T> All();

        T Find(int id);

        void Add(T entity);

        void Delete(int id);

        void Delete(T entity);

        void Update(T entity);

        int SaveChanges();
    }
}