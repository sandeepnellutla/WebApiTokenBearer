using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace MSTCloud.Controllers
{
    public class HomeController : ApiController
    {
        public IHttpActionResult Index()
        {
            return Ok();
        }
    }
}
