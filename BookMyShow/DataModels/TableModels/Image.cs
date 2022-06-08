using System.ComponentModel.DataAnnotations.Schema;

namespace BookMyShow.Controllers
{

  [Table("Image")]
  public class Image
  {
    public int Id { get; set; }

    public int MovieId { get; set; }

    public byte[] MovieImage { get; set; }
  }
}
