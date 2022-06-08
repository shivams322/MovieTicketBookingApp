using BookMyShow.Enums;

namespace BookMyShow.Models
{
    public class MovieModel
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public string Language { get; set; }

        public DateTime ReleaseDate { get; set; }

        public List<string> Genre { get; set; }

        public string Duration { get; set; }

        public byte[] MovieImage { get; set; }


  }
}
