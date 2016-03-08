using System.Linq;
using System.Threading;
using System.Web.Http;
using SocialCooking.Domain.Abstract;
using SocialCooking.Domain.Entity;

namespace SocialCooking.API.Controllers
{
    //[Authorize]
    [RoutePrefix("api/Home")]
    public class HomeController : ApiController
    {
        private readonly IDishRepository _ingredientRepo;

        public HomeController(IDishRepository ingredientRepo)
        {
            _ingredientRepo = ingredientRepo;
        }

        public IHttpActionResult Get()
        {
            return Ok();
        }
    }
}