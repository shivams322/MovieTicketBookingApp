using AutoMapper;
using BookMyShow.Data;
using BookMyShow.DataModels;
using BookMyShow.DataModels.TableModels;
using BookMyShow.Models;

namespace BookMyShow.Services
{
    public class UserService : IUserService
    {
        private readonly IMapper Mapper;

        private BookMyShowContext Context;
        public UserService(IMapper mapper,BookMyShowContext context)
        {
            Mapper = mapper;
            this.Context = context;
        }

        public int UserRegistration(User user)
        {
            Context.Db.Insert(user);
            return user.Id;
        }

        public User GetUser(Userdto request)
        {
            return this.Context.Db.FirstOrDefault<User>("WHERE email=@0 AND password=@1",request.Email,request.Password);
        }

    }
}
