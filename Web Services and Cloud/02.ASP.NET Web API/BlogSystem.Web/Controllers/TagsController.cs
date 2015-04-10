using BlogSystem.Data;

namespace BlogSystem.Web.Controllers
{
    using System.Linq;
    using System.Web.Http;
    using BlogSystem.Models;
    using Models;

    public class TagsController : ApiController
    {
        protected IBlogSystemData data;

        protected TagsController()
            : this(new BlogSystemData(new BlogSystemDbContext()))
        {
        }

        protected TagsController(IBlogSystemData data)
        {
            this.data = data;
        }

        [HttpGet]
        public IHttpActionResult All()
        {
            var tags = this.data
                .Tags
                .All()
                .Select(TagOutputData.FromTag);

            return Ok(tags);
        }

        [HttpPost]
        public IHttpActionResult Create(int id, TagOutputData tag)
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

            var newTag = new Tag
            {
                Name = tag.Name,
            };

            exisitingPost.Tags.Add(newTag);
            this.data.SaveChanges();

            return Ok(newTag.Id);
        }

        [HttpPut]
        public IHttpActionResult Update(int id, TagOutputData tag)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var exisitingTag = this.data.Tags.All().FirstOrDefault(u => u.Id == id);
            if (exisitingTag == null)
            {
                return BadRequest("Such tag does not exists!");
            }

            exisitingTag.Name = tag.Name ?? exisitingTag.Name;

            this.data.Tags.Update(exisitingTag);
            this.data.SaveChanges();

            return Ok();
        }

        [HttpDelete]
        public IHttpActionResult Remove(int id)
        {
            var exisitingTag = this.data.Tags.All().FirstOrDefault(u => u.Id == id);
            if (exisitingTag == null)
            {
                return BadRequest("Such tag does not exists!");
            }

            this.data.Tags.Delete(exisitingTag);
            this.data.SaveChanges();

            return Ok();
        }
    }
}
