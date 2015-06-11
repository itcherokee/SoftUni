using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LinkedIn.Web.Controllers
{
    using System.Data.Entity;
    using Data.UnitOfWork;
    using Models;

    public class UsersController : BaseController
    {
        public UsersController(ILinkedInData data) : base(data)
        {
        }

        public ActionResult Index(string username)
        {
            var user = this.Data.Users
                .All()
                .Include(x=>x.Certifications)
                .Where(x => x.UserName == username)
                .Select(UserViewModel.ViewModel)
                .FirstOrDefault();

            if (user == null)
            {
                return HttpNotFound("This is user do not exists.");
            }

            return View(user);
        }
    }
}