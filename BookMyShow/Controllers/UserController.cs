using BookMyShow.DataModels;
using BookMyShow.DataModels.TableModels;
using BookMyShow.Models;
using BookMyShow.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SimpleInjector;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BookMyShow.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    //[Authorize]
    public class UserController : ControllerBase
    {
        public IUserService UserService;

        public UserController(Container container)
        {
            UserService = container.GetInstance<IUserService>();
        }

        [HttpPost("signUp")]
        public int UserSignup(User user)
        {
            return UserService.UserRegistration(user);
        }

        [HttpPost("user")]
        public User GetUser(Userdto request)
        {
            return UserService.GetUser(request);
        }
    }
}
