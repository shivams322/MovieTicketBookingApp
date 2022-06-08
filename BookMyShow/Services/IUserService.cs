using BookMyShow.DataModels;
using BookMyShow.DataModels.TableModels;
using BookMyShow.Models;

namespace BookMyShow.Services
{
    public interface IUserService
    {
        int UserRegistration(User user);

        User GetUser(Userdto request);
    }
}
