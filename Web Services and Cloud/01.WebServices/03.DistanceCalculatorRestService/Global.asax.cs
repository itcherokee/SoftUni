using System.Web.Mvc;

namespace DistanceCalculatorRestService
{
    using System.Web.Http;
    using App_Start;

    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            GlobalConfiguration.Configure(WebApiConfig.Register);
        }
    }
}
