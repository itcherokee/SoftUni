using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace TestOne.Controllers
{
    public class CustomersController : ApiController
    {
        [HttpPost]
        public string GetCustomer(string id,[FromBody] bool includeOrders)
        {
            return includeOrders ? "custorm with orders" : "customer w/o orders";
        }
    }
}
