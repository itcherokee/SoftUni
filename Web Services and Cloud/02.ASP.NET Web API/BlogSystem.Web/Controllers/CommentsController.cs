using BlogSystem.Data;

namespace BlogSystem.Web.Controllers
{
    using System.Linq;
    using System.Web.Http;
    using BlogSystem.Models;
    using Models;

    public class CommentsController : ApiController
    {
        protected IBlogSystemData data;

        protected CommentsController()
            : this(new BlogSystemData(new BlogSystemDbContext()))
        {
        }

        protected CommentsController(IBlogSystemData data)
        {
            this.data = data;
        }

        [HttpGet]
        public IHttpActionResult All()
        {
            var comments = this.data
                .Comments
                .All()
                .Select(CommentOutputData.FromComment);

            return Ok(comments);
        }

        [HttpPost]
        public IHttpActionResult Create(int id, CommentOutputData comment)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var existingUser = this.data.Users.All().FirstOrDefault(u => u.Id == id);
            if (existingUser == null)
            {
                return BadRequest("Such user does not exists!");
            }

            var newComment = new Comment
            {
                Content = comment.Content,
            };

            existingUser.Comments.Add(newComment);
            this.data.SaveChanges();

            return Ok(newComment.Id);
        }

        [HttpPut]
        public IHttpActionResult Update(int id, CommentOutputData comment)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var existingComment = this.data.Comments.All().FirstOrDefault(u => u.Id == id);
            if (existingComment == null)
            {
                return BadRequest("Such comment does not exists!");
            }

            existingComment.Content = comment.Content ?? existingComment.Content;

            this.data.Comments.Update(existingComment);
            this.data.SaveChanges();

            return Ok();
        }

        [HttpDelete]
        public IHttpActionResult Remove(int id)
        {
            var exisitingComment = this.data.Comments.All().FirstOrDefault(u => u.Id == id);
            if (exisitingComment == null)
            {
                return BadRequest("Such comment does not exists!");
            }

            this.data.Comments.Delete(exisitingComment);
            this.data.SaveChanges();

            return Ok();
        }
    }
}
