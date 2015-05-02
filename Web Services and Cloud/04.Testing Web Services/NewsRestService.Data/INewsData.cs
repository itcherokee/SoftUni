namespace NewsRestService.Data
{
    using Repositories;
    using Model;

    public interface INewsData
    {
        IRepository<News> News { get; }

        int SaveChanges();
    }
}