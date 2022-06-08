namespace BookMyShow.Models
{
    public class TicketModel
    {
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
