namespace BugTracker.RestServices.Controllers
{
    using System;
    using System.Linq;
    using System.Web.Http;
    using Microsoft.AspNet.Identity;

    using Data.Models;
    using Models.BindingModels;
    using Models.DataModels;
    
    public class CommentsController : BasicApiController
    {
        // GET /api/comments
        [HttpGet]
        public IHttpActionResult GetAllComments()
        {
            var comments = this.data.Comments
                .OrderByDescending(c => c.DateCreated)
                .Select(CommentFullDataModel.DataModel).ToList();

            return this.Ok(comments);
        }

        // GET /api/bugs/{id}/comments
        [Route("api/bugs/{id:int}/comments")]
        [HttpGet]
        public IHttpActionResult GetCommentsByBugId(int id)
        {
            var bug = this.data.Bugs.Find(id);
            if (bug == null)
            {
                return this.NotFound();
            }

            var comments = this.data.Comments
                .Where(b => b.BugId == id)
                .OrderByDescending(c => c.DateCreated)
                .Select(CommentDataModel.DataModel).ToList();

            return this.Ok(comments);
        }

        // POST /api/bugs/{id}/comments
        [HttpPost]
        [Route("api/bugs/{id:int}/comments", Name = "PostNewComment")]
        public IHttpActionResult AddCommentToBug(int id, CommentBindingModel comment)
        {
            if (comment == null)
            {
                return this.BadRequest();
            }

            if (string.IsNullOrEmpty(comment.Text))
            {
                return this.BadRequest();
            }

            var bug = this.data.Bugs.Find(id);
            if (bug == null)
            {
                return this.NotFound();
            }

            var newComment = new Comment
            {
                BugId = bug.Id,
                Text = comment.Text,
                DateCreated = DateTime.Now,
            };

            var author = this.User.Identity.GetUserId();
            if (author != null)
            {
                newComment.AuthorId = this.User.Identity.GetUserId();
            }

            data.Comments.Add(newComment);
            data.SaveChanges();

            if (author != null)
            {
                return this.Ok(new
                {
                    Id = newComment.Id,
                    Author = this.User.Identity.GetUserName(),
                    Message = string.Format("User comment added for bug #{0}", bug.Id)
                });
            }

            return this.Ok(new
            {
                Id = newComment.Id,
                Message = string.Format("Added anonymous comment for bug #{0}", bug.Id)
            });
        }
    }
}
