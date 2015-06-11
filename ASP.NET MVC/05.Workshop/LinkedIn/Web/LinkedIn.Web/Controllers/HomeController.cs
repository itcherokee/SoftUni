using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LinkedIn.Web.Controllers
{
    using Data.UnitOfWork;
    using System.Web.Mvc.Expressions;

    public class HomeController : BaseController
    {
        public HomeController(ILinkedInData data)
            : base(data)
        {
        }

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {

            return this.RedirectToAction(x => x.Contact());
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}