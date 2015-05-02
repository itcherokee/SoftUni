namespace BugTracker.Tests
{
    using System;
    using System.Linq;
    using System.Net;
    using System.Net.Http;
    using System.Threading;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    using Models;

    /// <summary>
    /// Summary description for BugCommentsIntegrationTests
    /// </summary>
    [TestClass]
    public class BugCommentsIntegrationTests
    {
        [TestMethod]
        public void GetCommentsOfBug_ExisitngComments_ShouldReturnTwoComments()
        {
            // Arrange -> create a new bug with two comments
            TestingEngine.CleanDatabase();
            var bugTitle = "Bug title";
            var bugDescription = "Bug description";

            var httpPostResponse = TestingEngine.SubmitBugHttpPost(bugTitle, bugDescription);
            Assert.AreEqual(HttpStatusCode.Created, httpPostResponse.StatusCode);
            var submittedBug = httpPostResponse.Content.ReadAsAsync<BugModel>().Result;

            var httpPostResponseFirstComment =
                TestingEngine.SubmitCommentHttpPost(submittedBug.Id, "Comment 1");
            Assert.AreEqual(HttpStatusCode.OK, httpPostResponseFirstComment.StatusCode);
            Thread.Sleep(2);

            var httpPostResponseSecondComment =
                TestingEngine.SubmitCommentHttpPost(submittedBug.Id, "Comment 2");
            Assert.AreEqual(HttpStatusCode.OK, httpPostResponseSecondComment.StatusCode);

            // Act -> find the bug by its ID
            var httpResponse = TestingEngine.HttpClient.GetAsync("/api/bugs/" + submittedBug.Id + "/comments").Result;

            // Assert -> check if the bug by ID holds correct data
            Assert.AreEqual(HttpStatusCode.OK, httpResponse.StatusCode);
            var commentsFromService = httpResponse.Content.ReadAsAsync<CommentModel[]>().Result;

            Assert.AreEqual(2, commentsFromService.Count());

            Assert.IsTrue(commentsFromService[0].Id > 0);
            Assert.AreEqual("Comment 2", commentsFromService[0].Text);
            Assert.AreEqual(null, commentsFromService[0].Author);
            Assert.IsTrue(commentsFromService[0].DateCreated - DateTime.Now < TimeSpan.FromMinutes(1));

            Assert.IsTrue(commentsFromService[1].Id > 0);
            Assert.AreEqual("Comment 1", commentsFromService[1].Text);
            Assert.AreEqual(null, commentsFromService[1].Author);
            Assert.IsTrue(commentsFromService[1].DateCreated - DateTime.Now < TimeSpan.FromMinutes(1));
        }

        [TestMethod]
        public void GetCommentsOfBug_NonExisitngComments_ShouldReturnEmptyArrayForComments()
        {
            // Arrange -> create a new bug with two comments
            TestingEngine.CleanDatabase();
            var bugTitle = "Bug title";
            var bugDescription = "Bug description";

            var httpPostResponse = TestingEngine.SubmitBugHttpPost(bugTitle, bugDescription);
            Assert.AreEqual(HttpStatusCode.Created, httpPostResponse.StatusCode);
            var submittedBug = httpPostResponse.Content.ReadAsAsync<BugModel>().Result;

            // Act -> find the bug by its ID
            var httpResponse = TestingEngine.HttpClient.GetAsync("/api/bugs/" + submittedBug.Id + "/comments").Result;

            // Assert -> check if the bug by ID holds correct data
            Assert.AreEqual(HttpStatusCode.OK, httpResponse.StatusCode);
            var commentsFromService = httpResponse.Content.ReadAsAsync<CommentModel[]>().Result;

            Assert.AreEqual(0, commentsFromService.Count());
        }

        [TestMethod]
        public void GetCommentsOfBug_NonExisitngBug_ShouldReturnNotFound()
        {
            // Arrange -> create a new bug with two comments
            TestingEngine.CleanDatabase();
            int nonExistingBug = 1;

            // Act -> find the bug by its ID
            var httpResponse = TestingEngine.HttpClient.GetAsync("/api/bugs/" + nonExistingBug + "/comments").Result;

            // Assert -> check if the bug by ID holds correct data
            Assert.AreEqual(HttpStatusCode.NotFound, httpResponse.StatusCode);
        }

        [TestMethod]
        public void GetCommentsOfBugCheckSorting_ExisitngComments_ShouldReturnCommentsSortedByDatedescending()
        {
            // Arrange -> create a new bug with two comments
            TestingEngine.CleanDatabase();
            var bugTitle = "Bug title";
            var bugDescription = "Bug description";

            var httpPostResponse = TestingEngine.SubmitBugHttpPost(bugTitle, bugDescription);
            Assert.AreEqual(HttpStatusCode.Created, httpPostResponse.StatusCode);
            var submittedBug = httpPostResponse.Content.ReadAsAsync<BugModel>().Result;

            var httpPostResponseFirstComment =
                TestingEngine.SubmitCommentHttpPost(submittedBug.Id, "Comment 1");
            Assert.AreEqual(HttpStatusCode.OK, httpPostResponseFirstComment.StatusCode);
            Thread.Sleep(10);

            var httpPostResponseSecondComment =
                TestingEngine.SubmitCommentHttpPost(submittedBug.Id, "Comment 2");
            Assert.AreEqual(HttpStatusCode.OK, httpPostResponseSecondComment.StatusCode);

            // Act -> find the bug by its ID
            var httpResponse = TestingEngine.HttpClient.GetAsync("/api/bugs/" + submittedBug.Id + "/comments").Result;

            // Assert -> check if the bug by ID holds correct data
            Assert.AreEqual(HttpStatusCode.OK, httpResponse.StatusCode);
            var commentsFromService = httpResponse.Content.ReadAsAsync<CommentModel[]>().Result;

            Assert.AreEqual(2, commentsFromService.Count());
            Assert.IsTrue(commentsFromService[0].Id > commentsFromService[1].Id);
            Assert.IsTrue(commentsFromService[0].DateCreated > commentsFromService[1].DateCreated);
        }
    }
}
