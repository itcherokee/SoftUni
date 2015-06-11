namespace LinkedIn.Web.Controllers
{
    using System;
    using System.Linq;
    using System.Web.Mvc;
    using Data.UnitOfWork;
    using LinkedIn.Models;

    public abstract class BaseController : Controller
    {
        private ILinkedInData data;
        private User userProfile;

        protected BaseController(ILinkedInData data)
        {
            this.Data = data;
        }

        protected BaseController(ILinkedInData data, User userProfile)
            : this(data)
        {
            this.UserProfile = userProfile;
        }

        protected ILinkedInData Data
        {
            get { return this.data; }
            private set { this.data = value; }
        }

        protected User UserProfile
        {
            get { return this.userProfile; }
            private set { this.userProfile = value; }
        }

        protected override IAsyncResult BeginExecute(System.Web.Routing.RequestContext requestContext, AsyncCallback callback, object state)
        {
            if (requestContext.HttpContext.User.Identity.IsAuthenticated)
            {
                var username = requestContext.HttpContext.User.Identity.Name;
                var user = this.Data.Users.All().FirstOrDefault(x => x.UserName == username);
                this.UserProfile = user;
            }

            return base.BeginExecute(requestContext, callback, state);
        }
    }
}