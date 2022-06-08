namespace BookMyShow.Models
{
    public class ShowModel
    {
        public int Id { get; set; }

        public DateTime Date { get; set; }

        public DateTime StartTime { get; set; }

        public DateTime EndTime { get; set; }

        public int CinemaId { get; set; }

        public int MovieId { get; set; }

        public string Title { get; set; }

        public string CinemaName { get; set; }
    }
}
