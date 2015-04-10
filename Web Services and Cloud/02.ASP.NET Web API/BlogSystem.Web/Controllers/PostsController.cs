using BlogSystem.Data;

namespace BlogSystem.Web.Controllers
{
    using System.Linq;
    using System.Web.Http;
    using BlogSystem.Models;
    using Models;

    public class PostsController : ApiController
    {
        protected IBlogSystemData data;

        protected PostsController()
            : this(new BlogSystemData(new BlogSystemDbContext()))
        {
        }

        protected PostsController(IBlogSystemData data)
        {
            this.data = data;
        }

        [HttpGet]
        public IHttpActionResult All()
        {
            var posts = this.data
                .Posts
                .All()
                .Select(PostOutputData.FromPost);

            return Ok(posts);
        }

        [HttpPost]
        public IHttpActionResult Create(int id, PostOutputData post)
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

            var newPost = new Post
            {
                Title = post.Title,
                Content = post.Content
            };

            existingUser.Posts.Add(newPost);
            this.data.SaveChanges();

            return Ok(newPost.Id);
        }

        [HttpPut]
        public IHttpActionResult Update(int id, PostOutputData post)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var exisitingPost = this.data.Posts.All().FirstOrDefault(u => u.Id == id);
            if (exisitingPost == null)
            {
                return BadRequest("Such post does not exists!");
            }

            exisitingPost.Title = post.Title ?? exisitingPost.Title;
            exisitingPost.Content = post.Content ?? exisitingPost.Content;


            this.data.Posts.Update(exisitingPost);
            this.data.SaveChanges();

            return Ok();
        }

        [HttpDelete]
        public IHttpActionResult Remove(int id)
        {
            var exisitingPost = this.data.Posts.All().FirstOrDefault(u => u.Id == id);
            if (exisitingPost == null)
            {
                return BadRequest("Such post does not exists!");
            }

            this.data.Posts.Delete(exisitingPost);
            this.data.SaveChanges();

            return Ok();
        }
    }
}
