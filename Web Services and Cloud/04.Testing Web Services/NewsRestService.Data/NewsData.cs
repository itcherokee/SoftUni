namespace NewsRestService.Data
{
    using System;
    using System.Collections.Generic;

    using Repositories;
    using Model;

    public class NewsData : INewsData
    {
        private INewsDbContext context;
        private IDictionary<Type, object> repositories;

        public NewsData(INewsDbContext context)
        {
            this.context = context;
            this.repositories = new Dictionary<Type, object>();
        }

        public IRepository<News> News
        {
            get
            {
                return this.GetRepository<News>();
            }
        }

        public int SaveChanges()
        {
            return this.context.SaveChanges();
        }

        private IRepository<T> GetRepository<T>() where T : class
        {
            var type = typeof(T);
            if (!this.repositories.ContainsKey(type))
            {
                var repositoryType = typeof(Repository<T>);
                this.repositories.Add(typeof(T), Activator.CreateInstance(repositoryType, this.context));
            }

            return (IRepository<T>)this.repositories[type];
        }
    }
}
