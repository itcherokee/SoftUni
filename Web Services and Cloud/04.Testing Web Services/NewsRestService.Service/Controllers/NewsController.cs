using System.Net;
using NewsRestService.Data;

namespace NewsRestService.Service.Controllers
{
    using System.Globalization;
    using System.Linq;
    using System.Web.Http;

    using Model;

    public class NewsController : ApiController
    {
        protected INewsData data;

        public NewsController()
            : this(new NewsData(new NewsDbContext()))
        {
        }

        public NewsController(INewsData data)
        {
            this.data = data;
        }

        // GET api/news
        [HttpGet]
        public IHttpActionResult GetAll()
        {
            return this.Ok(this.data.News.All().OrderBy(n => n.PublishDate).ToList());
        }

        // POST api/news
        public IHttpActionResult Post(News news)
        {

            if (ModelState.IsValid && !string.IsNullOrWhiteSpace(news.Title))
            {
                
                this.data.News.Add(news);
                this.data.SaveChanges();

                return this.CreatedAtRoute("DefaultApi", new { id = news.Id}, news);
                // return this.Created(Request.RequestUri + news.Id.ToString(CultureInfo.InvariantCulture), news);
            }

            return this.BadRequest();
        }

        // PUT api/news/{id}
        public IHttpActionResult Put(News news)
        {
            if (news != null && news.Id > 0)
            {
                var entity = this.data.News.Find(news.Id);
                if (entity != null && entity.Id == news.Id)
                {
                    entity.Title = news.Title;
                    entity.Content = news.Content;
                    entity.PublishDate = news.PublishDate;
                    this.data.News.Update(entity);
                    this.data.SaveChanges();

                    return Content(HttpStatusCode.Accepted, entity);
                }
            }

            return this.BadRequest();
        }

        // DELETE api/news/{id}
        public IHttpActionResult Delete(int id)
        {
            var entity = this.data.News.Find(id);
            if (entity != null)
            {
                this.data.News.Delete(id);
                this.data.SaveChanges();

                return this.Ok();
            }

            return this.BadRequest();
        }
    }
}
