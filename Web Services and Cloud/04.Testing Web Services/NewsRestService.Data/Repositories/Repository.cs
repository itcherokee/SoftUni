namespace NewsRestService.Data.Repositories
{
    using System.Linq;
    using System.Data.Entity;

    public class Repository<T> : IRepository<T> where T : class
    {
        private DbContext context;
        private readonly IDbSet<T> set;

        public Repository()
            : this(new NewsDbContext())
        {
        }

        public Repository(DbContext context)
        {
            this.context = context;
            this.set = context.Set<T>();
        }

        public IQueryable<T> All()
        {
            return this.set;
        }

        public T Find(int id)
        {
            return this.set.Find(id);
        }

        public void Add(T entity)
        {
            this.ChangeEntityState(entity, EntityState.Added);
        }

        public void Delete(int id)
        {
            var entity = this.set.Find(id);
            this.Delete(entity);
        }

        public void Delete(T entity)
        {
            this.ChangeEntityState(entity, EntityState.Deleted);
        }

        public void Update(T entity)
        {
            this.ChangeEntityState(entity, EntityState.Modified);
        }

        public int SaveChanges()
        {
            return this.context.SaveChanges();
        }

        private void ChangeEntityState(T entity, EntityState state)
        {
            var entry = this.context.Entry(entity);
            if (entry.State == EntityState.Detached)
            {
                this.set.Attach(entity);
            }

            entry.State = state;
        }
    }
}
