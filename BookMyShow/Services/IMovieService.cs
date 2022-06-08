using BookMyShow.Models;

namespace BookMyShow.Services
{
    public interface IMovieService
    {
        List<MovieModel> GetMoviesList();

        MovieModel GetMovie(int id);

        bool AddMovies(MovieModel movie);
    }
}
