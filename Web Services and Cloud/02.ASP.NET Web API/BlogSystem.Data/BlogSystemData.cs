namespace BlogSystem.Data
{
    using System;
    using System.Collections.Generic;

    using Repositories;
    using Models;

    public class BlogSystemData : IBlogSystemData
    {
        private IBlogSystemDbContext context;
        private IDictionary<Type, object> repositories; 

        public BlogSystemData(IBlogSystemDbContext context)
        {
            this.context = context;
            this.repositories = new Dictionary<Type, object>();
        }

        public IBlogSystemDbContext Context
        {
            get { return this.context; }
        }

        public IRepository<User> Users
        {
            get { return this.GetRepository<User>(); }
        }

        public IRepository<Post> Posts
        {
            get { return this.GetRepository<Post>(); }
        }

        public IRepository<Comment> Comments
        {
            get { return this.GetRepository<Comment>(); }
        }

        public IRepository<Tag> Tags
        {
            get { return this.GetRepository<Tag>(); }
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
//                if (typeof(T).IsAssignableFrom(type))
//                {
//                    repositoryType = typeof(T);
//                }

                this.repositories.Add(typeof(T), Activator.CreateInstance(repositoryType, this.context));
            }

            return (IRepository<T>)this.repositories[type];
        }
    }
}
