using BookMyShow.Enums;
using System.ComponentModel.DataAnnotations.Schema;

namespace BookMyShow.DataModels
{
    [Table("MovieList")]
    public class MovieList
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public Language Language { get; set; }

        public DateTime ReleaseDate { get; set; }

        public string Genre { get; set; } 

        public string Duration { get; set; }

        public byte[] MovieImage   { get; set; }
    }
}
