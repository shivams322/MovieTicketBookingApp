using AutoMapper;
using BookMyShow.Data;
using BookMyShow.DataModels;
using BookMyShow.Models;

namespace BookMyShow.Services
{
    public class ShowService : IShowService
    {
        private readonly IMapper Mapper;

        private BookMyShowContext Context;
        public ShowService(IMapper mapper, BookMyShowContext context)
        {
            this.Mapper = mapper;
            this.Context = context;
        }
        public List<ShowModel> GetAllShows()
        {
            var shows = Context.Db.Fetch<ShowList>(string.Empty);
            return Mapper.Map<IList<ShowList>, IList<ShowModel>>(shows).ToList();
        }

        public List<ShowModel> GetShows(int id)
        {
            var show = Context.Db.Fetch<ShowList>("where MovieId = @0", id);
            return Mapper.Map<IList<ShowList>,IList<ShowModel>>(show).ToList();
        }

        public int GetCinemaTotalSeat(int cinemaId)
        {
            return this.Context.Db.FirstOrDefault<Cinema>("where Id = @0",cinemaId).TotalSeats;
        }
    }
}
