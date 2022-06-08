using System.ComponentModel.DataAnnotations.Schema;

namespace BookMyShow.DataModels
{
    [Table("Cinema")]
    public class Cinema
    {
        public int Id { get; set; }

        public string CinemaName { get; set; }

        public int TotalSeats { get; set; }

    }
}
