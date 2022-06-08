using System.ComponentModel.DataAnnotations.Schema;

namespace BookMyShow.Models.CoreModels
{
  [Table("ImageModel")]
  public class ImageModel
  { 
    public int Id { get; set; }

    public int MovieId { get; set; }

    public string MovieImage { get; set; }
  }
}
