namespace BlogSystem.Data
{
    using System;

    using BlogSystem.Data.Repositories;
    using BlogSystem.Models;

    public interface IBlogSystemData
    {
        IRepository<User> Users { get; }

        IRepository<Post> Posts { get; }

        IRepository<Comment> Comments { get; }

        IRepository<Tag> Tags { get; }

        int SaveChanges();
    }
}
