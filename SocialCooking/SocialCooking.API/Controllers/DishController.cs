using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using AutoMapper;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using SocialCooking.API.Models;
using SocialCooking.Domain.Abstract;
using SocialCooking.Domain.Concrete;
using SocialCooking.Domain.Entity;

namespace SocialCooking.API.Controllers
{
    [Authorize]
    [RoutePrefix("api/Dish")]
    public class DishController : ApiController
    {
        private IDishRepository _dishRepo;
        private AuthRepository authContext;
        public DishController(IDishRepository dishRepository)
        {
            authContext = new AuthRepository();
            _dishRepo = dishRepository;
        }

        [HttpPost]
        public async Task<HttpResponseMessage> AddDish([FromBody] DishViewModel dish)
        {
            string userName = RequestContext.Principal.Identity.Name;
            IdentityUser user = await authContext.FindUserByUserName(userName);
            dish.AuthorId = user.Id;
            dish.Archived = false;
            dish.Published = true;
            Mapper.CreateMap<DishViewModel, Dish>();
            Dish newDish = Mapper.Map<DishViewModel, Dish>(dish);

            newDish = _dishRepo.AddDishFromViewModel(newDish);

            Mapper.CreateMap<Dish, DishViewModel>();
            DishViewModel newDishVm = Mapper.Map<Dish, DishViewModel>(newDish);
            return Request.CreateResponse(HttpStatusCode.OK, newDishVm);
        }

    }
}