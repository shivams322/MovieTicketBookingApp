using BookMyShow.DataModels;
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
  [Authorize]
  public class MovieController : ControllerBase
  {
    public IMovieService MovieService;

    public MovieController(Container container)
    {
      MovieService = container.GetInstance<IMovieService>();
    }

    [HttpPost("addMovie")]
    public bool AddMovie(MovieModel movie)
    {
      return MovieService.AddMovies(movie);
    }

    [HttpGet("movieDetail/{id}")]
    public MovieModel GetMovie(int id)
    {
      return MovieService.GetMovie(id);
    }

    [HttpGet("allMovies")]
    public List<MovieModel> GetMovie()
    {
      return MovieService.GetMoviesList();
    }
  }
}
