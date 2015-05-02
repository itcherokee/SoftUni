namespace BugTracker.RestServices.Controllers
{
    using System.Data.Entity;
    using System.Web.Http;

    using Data;
    
    public abstract class BasicApiController : ApiController
    {
        protected BugTrackerDbContext data;

        protected BasicApiController()
            : this(new BugTrackerDbContext())
        {
        }

        protected BasicApiController(BugTrackerDbContext context)
        {
            this.data = context;
        }
    }
}
