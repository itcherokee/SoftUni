using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using System.Web.Http.Results;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using NewsRestService.Data;
using NewsRestService.Model;
using NewsRestService.Service.Controllers;

namespace NewsRestService.Service.UnitTests
{
    [TestClass]
    public class NewsControllerTests
    {
        [TestMethod]
        public void GetNews_ReturnsOkAndAllNews()
        {
            // Arange
            var mockRepository = new Mock<INewsData>();
            News[] news = 
            {
                new News {Title = "News number 1", Content = "Content of first news", PublishDate = DateTime.Now},
                new News {Title = "News number 2", Content = "Content of second news", PublishDate = DateTime.Now},
                new News {Title = "News number 3", Content = "Content of third news", PublishDate = DateTime.Now},
            };

            mockRepository.Setup(rep => rep.News.All()).Returns(news.AsQueryable());

            var controller = new NewsController(mockRepository.Object);

            // Act
            IHttpActionResult result = controller.GetAll();
            var contentResult = result as OkNegotiatedContentResult<List<News>>;

            // Assert
            Assert.IsNotNull(contentResult);
            Assert.IsInstanceOfType(result, typeof(OkNegotiatedContentResult<List<News>>));
            Assert.IsNotNull(contentResult.Content);
            Assert.AreEqual(3, contentResult.Content.Count);
        }

        [TestMethod]
        public void CreateNews_WithValidNews_ReturnsCreatedAndLocation()
        {
            // Arange
            var mockRepository = new Mock<INewsData>();
            List<News> news = new List<News>();

            mockRepository.Setup(rep => rep.News.Add(It.IsAny<News>())).Callback((News n) => news.Add(n));

            var controller = new NewsController(mockRepository.Object);

            // Act
            IHttpActionResult result = controller.Post(new News { Id = 100, Title = "News number 1", Content = "Content of first news", PublishDate = DateTime.Now });
            var createdResult = result as CreatedAtRouteNegotiatedContentResult<News>;

            // Assert
            Assert.IsNotNull(createdResult);
            Assert.AreEqual("DefaultApi", createdResult.RouteName);
            Assert.AreEqual(100, createdResult.RouteValues["id"]);
            Assert.IsInstanceOfType(result, typeof(CreatedAtRouteNegotiatedContentResult<News>));
            Assert.IsNotNull(createdResult.Content);
        }

        [TestMethod]
        public void CreateNews_WithInvalidNews_ReturnsBadRequest()
        {
            // Arange
            var mockRepository = new Mock<INewsData>();
            var controller = new NewsController(mockRepository.Object);

            // Act
            IHttpActionResult result = controller.Post(new News { });

            // Assert
            Assert.IsInstanceOfType(result, typeof(BadRequestResult));
        }

        [TestMethod]
        public void UpdateNews_WithValidNews_ReturnsOKAndModifiedNews()
        {
            // Arange
            var mockRepository = new Mock<INewsData>();
            News[] news = 
            {
                new News { Id = 100, Title = "News number 1", Content = "Content of first news", PublishDate = DateTime.Now }
            };

            mockRepository.Setup(rep => rep.News.Update(It.IsAny<News>())).Verifiable();
            mockRepository.Setup(rep => rep.News.Find(It.IsAny<int>())).Returns(news.First());
            var modifiedNewsItem = new News { Id = 100, Title = "Modified title", Content = "Content of first news", PublishDate = DateTime.Now };

            var controller = new NewsController(mockRepository.Object);

            // Act
            IHttpActionResult result = controller.Put(modifiedNewsItem);
            var updatedResult = result as NegotiatedContentResult<News>;

            // Assert
            Assert.IsNotNull(updatedResult);
            Assert.AreEqual("Modified title", updatedResult.Content.Title);
            Assert.IsInstanceOfType(result, typeof(NegotiatedContentResult<News>));
            Assert.IsNotNull(updatedResult.Content);
        }

        [TestMethod]
        public void UpdateNews_WithInvalidNews_ReturnsBadRequest()
        {
            // Arange
            var mockRepository = new Mock<INewsData>();
            var controller = new NewsController(mockRepository.Object);

            // Act
            IHttpActionResult result = controller.Put(new News());

            // Assert
            Assert.IsInstanceOfType(result, typeof(BadRequestResult));
        }

        [TestMethod]
        public void UpdateNews_WithNonExisitngNewsNews_ReturnsBadRequest()
        {
            // Arange
            var mockRepository = new Mock<INewsData>();
            News[] news = 
            {
                new News { Id = 100, Title = "News number 1", Content = "Content of first news", PublishDate = DateTime.Now }
            };

            mockRepository.Setup(rep => rep.News.Update(It.IsAny<News>())).Verifiable();
            mockRepository.Setup(rep => rep.News.Find(It.IsAny<int>())).Returns(news.First());
            var modifiedNewsItem = new News { Id = 1000, Title = "Modified title", Content = "Content of first news", PublishDate = DateTime.Now };

            var controller = new NewsController(mockRepository.Object);

            // Act
            IHttpActionResult result = controller.Put(modifiedNewsItem);

            // Assert
            Assert.IsInstanceOfType(result, typeof(BadRequestResult));
        }
        
        [TestMethod]
        public void DeleteNews_ExisitngNews_ReturnsOKAndModifiedNews()
        {
            // Arange
            var mockRepository = new Mock<INewsData>();
            var newsItem = new News
            {
                Id = 100,
                Title = "News number 1",
                Content = "Content of first news",
                PublishDate = DateTime.Now
            };

            var news = new List<News> 
            {
                newsItem
            };

            mockRepository.Setup(rep => rep.News.Delete(It.IsAny<int>())).Callback(()=>news.Remove(newsItem));
            mockRepository.Setup(rep => rep.News.Find(It.IsAny<int>())).Returns(news.First());

            var controller = new NewsController(mockRepository.Object);

            // Act
            IHttpActionResult result = controller.Delete(100);

            // Assert
            Assert.IsInstanceOfType(result, typeof(OkResult));
            Assert.AreEqual(0, news.Count);
        }

        [TestMethod]
        public void DeleteNews_NonExisitingNews_ReturnsBadRequest()
        {
            // Arange
            var mockRepository = new Mock<INewsData>();
            mockRepository.Setup(rep => rep.News.Delete(It.IsAny<int>())).Verifiable();
            var controller = new NewsController(mockRepository.Object);

            // Act
            IHttpActionResult result = controller.Delete(7);

            // Assert
            Assert.IsInstanceOfType(result, typeof(BadRequestResult));
        }
    }
}
