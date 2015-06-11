namespace LinkedIn.Data.UnitOfWork
{
    using System;
    using System.Collections.Generic;
    using Models;
    using Repositories;

    public class LinkedInData : ILinkedInData
    {
        private readonly ILinkedInDbContext context;
        private readonly IDictionary<Type, object> repositories;

        public LinkedInData(ILinkedInDbContext context)
        {
            this.context = context;
            this.repositories = new Dictionary<Type, object>();
        }

        public IRepository<User> Users { get { return this.GetReposaitory<User>(); } }

        public IRepository<Certification> Certifications { get { return this.GetReposaitory<Certification>(); } }

        public IRepository<Discussion> Discussions { get { return this.GetReposaitory<Discussion>(); } }

        public IRepository<Experience> Experiences { get { return this.GetReposaitory<Experience>(); } }

        public IRepository<Group> Groups { get { return this.GetReposaitory<Group>(); } }

        public IRepository<UserLanguage> UserLanguages { get { return this.GetReposaitory<UserLanguage>(); } }

        public IRepository<Project> Projects { get { return this.GetReposaitory<Project>(); } }

        public IRepository<Skill> Skills { get { return this.GetReposaitory<Skill>(); } }

        public IRepository<Endorcement> Endorcements { get { return this.GetReposaitory<Endorcement>(); } }

        public IRepository<AdministrationLog> AdministrationLogs { get { return this.GetReposaitory<AdministrationLog>(); } }

        public int SaveChanges()
        {
            return this.context.SaveChanges();
        }

        private IRepository<T> GetReposaitory<T>() where T : class
        {
            var type = typeof(T);
            if (!this.repositories.ContainsKey(type))
            {
                var typeOfRepository = typeof(Repository<T>);
                //                if (type.IsAssignableFrom(typeof(T)))
                //                {
                //                    typeOfRepository = typeof (IRepository<T>);
                //                }

                var repository = Activator.CreateInstance(typeOfRepository, this.context);
                this.repositories.Add(type, repository);
            }

            return (IRepository<T>)this.repositories[type];
        }
    }
}
