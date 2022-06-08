namespace BookMyShow.Models
{
    public class BookingModel
    {
        public int Id { get; set; }

        public int NoOfSeats { get; set; }

        public int UserId { get; set; }

        public int ShowId { get; set; }

        public List<int> SeatNumbers { get; set; }
    }
}
