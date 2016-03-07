using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace SocialCooking.API.Controllers
{
    [RoutePrefix("api/Home")]
    public class HomeController : ApiController
    {

        public HomeController()
        {
        }

        public IHttpActionResult Get()
        {
            return Ok();
        }
    }
}