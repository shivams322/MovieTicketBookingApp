using AutoMapper;
using AutoMapper.Internal;
using BookMyShow.Data;
using BookMyShow.DataModels;
using BookMyShow.Models;
using System.Linq;

namespace BookMyShow.Services
{ 
    public class MovieService : IMovieService
    {
        private readonly IMapper Mapper;

        private BookMyShowContext Context;

        public MovieService(IMapper mapper,BookMyShowContext context)
        {
            this.Mapper = mapper;
            this.Context = context;
        }

        public List<MovieModel> GetMoviesList()
        {
            var movies = this.Context.Db.Fetch<MovieList>(string.Empty);
            var movieList = this.Mapper.Map<IList<MovieList>, IList<MovieModel>>(movies).ToList();
            
            return movieList;
        }

        public MovieModel GetMovie(int id)
        {
            var movie=this.Context.Db.FirstOrDefault<MovieList>("where id=@0",id);
            return this.Mapper.Map<MovieList,MovieModel>(movie); 
        }

        public bool AddMovies(MovieModel movie)
        {
            var movies= this.Mapper.Map<MovieModel,MovieList>(movie);
            this.Context.Db.Insert(movies);
            if (!this.Context.Db.Exists<MovieList>(movies)) return false;
            return true;
        }

    }

}
