using DistanceCalculatorRestService.Models;

namespace DistanceCalculatorRestService.Controllers
{
    using System;
    using System.Web.Http;

    public class DistanceController : ApiController
    {
        [HttpPost]
        public IHttpActionResult CalculateDistance([FromBody]DualPoint points)
        {
            double deltaX = points.X2 - points.X1;
            double deltaY = points.Y2 - points.Y1;
            double distance = Math.Sqrt((deltaX * deltaX) + (deltaY * deltaY));

            return Ok(distance);
        }

//        public IHttpActionResult Post(int x1, int y1, int x2, int y2)
//        {
//            double deltaX = x2 - x1;
//            double deltaY = y2 - y1;
//            double distance = Math.Sqrt((deltaX * deltaX) + (deltaY * deltaY));
//
//            return Ok(distance);
//        }

        public int Get()
        {
            return 5;
        }
    }
}
