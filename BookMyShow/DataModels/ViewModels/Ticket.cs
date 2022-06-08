using System.ComponentModel.DataAnnotations.Schema;

namespace BookMyShow.DataModels
{
    [Table("Ticket")]
    public class Ticket
    {
        public int Id { get; set; }

        public int BookingId { get; set; }

        public int ShowId { get; set; }

        public string Name { get; set; }

        public string MovieName { get; set; }

        public string Cinema { get; set; }

        public DateTime MovieTimings { get; set; }

        public int NoOfSeats { get; set; }

        public int SeatNumber { get; set; }
    }
}
