namespace NewRestService.Data.UnitTests
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity.Validation;
    using System.Linq;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using NewsRestService.Data.Repositories;
    using NewsRestService.Model;

    [TestClass]
    public class NewsRepositoriesTests
    {
        [TestMethod]
        public void ListAllNews_ReturnsFourNews()
        {
            // Arrange
            IRepository<News> repository = new Repository<News>();
            ClearDatabase(repository);
            SeedNews(repository);
            List<News> news = ListOfNews;
            var comparer = new NewsComparer();

            //Act
            List<News> newsFromDb = repository.All().ToList();

            //Assert
            CollectionAssert.AreEqual(news, newsFromDb, comparer, "Returned data from EF are not equal");
            Assert.AreEqual(news.Count, newsFromDb.Count, "Count of news is not equal.");
        }

        [TestMethod]
        public void AddNews_ValidNewsAddedToDb_ShouldReturnNews()
        {
            // Arrange -> prapare the objects
            var newValidNews = new News { Title = "Valid news added", Content = "Something", PublishDate = DateTime.Now };
            IRepository<News> repository = new Repository<News>();

            // Act -> perform some logic
            repository.Add(newValidNews);
            repository.SaveChanges();

            // Assert -> validate the results
            var newsFromDb = repository.Find(newValidNews.Id);

            Assert.IsNotNull(newsFromDb);
            Assert.AreEqual(newValidNews.Title, newsFromDb.Title);
            Assert.AreEqual(newValidNews.Content, newsFromDb.Content);
            Assert.AreEqual(newValidNews.PublishDate, newsFromDb.PublishDate);
            Assert.IsTrue(newsFromDb.Id != 0);
        }

        [TestMethod]
        [ExpectedException(typeof(DbEntityValidationException))]
        public void AddNews_InValidNewsAddedToDb_ShouldThrowException()
        {
            // Arrange -> prapare the objects
            var newInvalidNews = new News { Title = "Invalid", Content = "Something", PublishDate = DateTime.Now };
            IRepository<News> repository = new Repository<News>();

            // Act -> perform some logic
            repository.Add(newInvalidNews);
            repository.SaveChanges();
        }

        [TestMethod]
        public void ModifyNews_ValidNews_ShouldModifyNews()
        {
            // Arrange -> prapare the objects
            IRepository<News> repository = new Repository<News>();
            ClearDatabase(repository);
            SeedNews(repository);
            var newsFromDb = repository.All().FirstOrDefault();
            string title = "Modified Title";
            var content = "Modified Content";
            var dateTimeNow = DateTime.Now;

            // Act -> perform some logic
            newsFromDb.Title = title;
            newsFromDb.Content = content;
            newsFromDb.PublishDate = dateTimeNow;
            repository.SaveChanges();

            // Assert -> validate the results
            var modifiedNewsFromDb = repository.Find(newsFromDb.Id);
            Assert.IsNotNull(modifiedNewsFromDb);
            Assert.AreEqual(content, modifiedNewsFromDb.Content);
            Assert.AreEqual(title, modifiedNewsFromDb.Title);
            Assert.AreEqual(dateTimeNow.ToString(), modifiedNewsFromDb.PublishDate.ToString());
        }


        [TestMethod]
        [ExpectedException(typeof(DbEntityValidationException))]
        public void ModifyNews_WithInValidNews_ShouldThrowException()
        {
            // Arrange -> prapare the objects
            IRepository<News> repository = new Repository<News>();
            ClearDatabase(repository);
            SeedNews(repository);
            var newsFromDb = repository.All().FirstOrDefault();
            string title = "";
            var content = "Modified Content";
            var dateTimeNow = DateTime.Now;

            // Act -> perform some logic
            newsFromDb.Title = title;
            newsFromDb.Content = content;
            newsFromDb.PublishDate = dateTimeNow;
            repository.SaveChanges();

            // Assert -> validate the results
        }

        [TestMethod]
        [ExpectedException(typeof(NullReferenceException))]
        public void ModifyNews_NonExistingNews_ShouldThrowException()
        {
            // Arrange -> prapare the objects
            IRepository<News> repository = new Repository<News>();
            ClearDatabase(repository);
            SeedNews(repository);
            var newsFromDb = repository.Find(1000000);
            string title = "";
            var content = "Modified Content";
            var dateTimeNow = DateTime.Now;

            // Act -> perform some logic
            newsFromDb.Title = title;
            newsFromDb.Content = content;
            newsFromDb.PublishDate = dateTimeNow;
            repository.SaveChanges();

            // Assert -> validate the results
        }

        [TestMethod]
        public void DeleteNews_ExistingNews_ShouldDeleteNews()
        {
            // Arrange -> prapare the objects
            IRepository<News> repository = new Repository<News>();
            ClearDatabase(repository);
            SeedNews(repository);
            var newsFromDb = repository.All().FirstOrDefault();

            // Act -> perform some logic
            repository.Delete(newsFromDb.Id);
            repository.SaveChanges();

            // Assert -> validate the results
            var deletedNewsFromDb = repository.Find(newsFromDb.Id);
            Assert.IsNull(deletedNewsFromDb);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void DeleteNews_NonExistingNews_ShouldThrowException()
        {
            // Arrange -> prapare the objects
            IRepository<News> repository = new Repository<News>();
            ClearDatabase(repository);
            SeedNews(repository);
            var newsFromDb = repository.Find(1000000);

            // Act -> perform some logic
            repository.Delete(newsFromDb);
            repository.SaveChanges();

            // Assert -> validate the results
        }




















        private static void ClearDatabase(IRepository<News> repository)
        {
            foreach (var news in repository.All())
            {
                repository.Delete(news.Id);
            }

            repository.SaveChanges();
        }


        private static void SeedNews(IRepository<News> repository)
        {
            var newsList = ListOfNews;

            foreach (var news in newsList)
            {
                repository.Add(news);
            }

            repository.SaveChanges();
        }

        private static List<News> ListOfNews
        {
            get
            {
                return new List<News>
                {
                    new News
                    {
                        Title = "New transactions in EF",
                        Content = "There is a lot of new things in EF6",
                        PublishDate = new DateTime(2013, 1, 23)
                    },
                    new News
                    {
                        Title = "New MVC 101 Course",
                        Content = "Come to us to take your money, but get knowledge",
                        PublishDate = new DateTime(2014, 10, 01)
                    },
                    new News
                    {
                        Title = "Microsoft has been bought by IndianWare",
                        Content = "And here comes the end of the MS hegemony",
                        PublishDate = new DateTime(2014, 4, 1, 10, 10, 00)
                    },
                    new News
                    {
                        Title = "Do you study for the next exam",
                        Content = "Stop and come to us",
                        PublishDate = new DateTime(2015, 4, 13)
                    },
                };
            }
        }
    }
}
