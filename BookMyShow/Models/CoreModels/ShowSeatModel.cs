using BookMyShow.Enums;

namespace BookMyShow.Models
{
    public class ShowSeatModel
    {
        public int Price { get; set; }

        public string Status { get; set; }

        public int SeatNumber { get; set; }

        public int ShowId { get; set; }

        public int BookingId { get; set; }

        public int CinemaId { get; set; }
    }
}
