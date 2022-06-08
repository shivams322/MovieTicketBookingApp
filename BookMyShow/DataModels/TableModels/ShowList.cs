using System.ComponentModel.DataAnnotations.Schema;

namespace BookMyShow.DataModels
{
    [Table("ShowList")]
    public class ShowList
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
