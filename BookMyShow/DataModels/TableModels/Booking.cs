using System.ComponentModel.DataAnnotations.Schema;

namespace BookMyShow.DataModels
{
    [Table("Booking")]
    public class Booking
    {
        public int Id { get; set; }

        public int NoOfSeats { get; set; }

        public DateTime BookTime { get; set; } = DateTime.Now;

        public int UserId { get; set; }

        public int ShowId { get; set; }

    }
}
