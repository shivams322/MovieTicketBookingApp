using BookMyShow.DataModels;
using BookMyShow.Models;

namespace BookMyShow.Services
{
    public interface IShowService
    {
        List<ShowModel> GetAllShows();

        List<ShowModel> GetShows(int id);

        int GetCinemaTotalSeat(int cinemaId);
    }
}
