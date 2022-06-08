using BookMyShow.Enums;
using System.ComponentModel.DataAnnotations.Schema;

namespace BookMyShow.DataModels
{
    [Table("ShowSeat")]
    public class ShowSeat //bookedshowseat
    {
        public int Id { get; set; }

        public int Price { get; set; }

        public string Status { get; set; }

        public int SeatNumber { get; set; }

        public int ShowId { get; set; }

        public int BookingId { get; set; }

        public int CinemaId { get; set; }
    }
}
