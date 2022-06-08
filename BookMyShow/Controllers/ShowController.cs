using BookMyShow.DataModels;
using BookMyShow.Models;
using BookMyShow.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SimpleInjector;

namespace BookMyShow.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  [Authorize]
  public class ShowController : ControllerBase
  {
    public IShowService ShowService;

    public ShowController(Container container)
    {
      ShowService = container.GetInstance<IShowService>();
    }

    [HttpGet("allShows")]
    public List<ShowModel> GetShows()
    {
      return ShowService.GetAllShows();
    }

    [HttpGet("movie/shows/{id}")]
    public List<ShowModel> GetShow(int id)
    {
      return ShowService.GetShows(id);
    }

    [HttpGet("totalseats/{cinemaId}")]
    public int GetCinemaTotalSeat(int cinemaId)
    {
      return ShowService.GetCinemaTotalSeat(cinemaId);
    }
  }
}
