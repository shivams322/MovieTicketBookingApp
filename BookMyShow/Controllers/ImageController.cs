using AutoMapper;
using BookMyShow.Data;
using BookMyShow.Models.CoreModels;
using Microsoft.AspNetCore.Mvc;


namespace BookMyShow.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class ImageController : ControllerBase
  {
    private BookMyShowContext Context;

    public ImageController(BookMyShowContext context)
    {
      Context = context;
    }

    [HttpPost("postimage")]
    public bool PostImage(int movieId,IFormFile files)
    {
      if (files != null)
      {
        if (files.Length > 0)
        {
          var fileName = Path.GetFileName(files.FileName);
          var fileExtension = Path.GetExtension(fileName);
          var objfiles = new Image();

          using (var target = new MemoryStream())
          {
            files.CopyTo(target);
            objfiles.MovieId=movieId; 
            objfiles.MovieImage = target.ToArray();
          }
          if (fileExtension.ToLower() == ".jpg" || fileExtension.ToLower() == ".png")
          { this.Context.Db.Insert(objfiles); }
          else
          { return false; }

        }
      }
      return true;
    }

    [HttpGet("{movieId}")]
    public Image GetMovieImage(int movieId)
    {
      return this.Context.Db.FirstOrDefault<Image>("where MovieId=@0", movieId);
      
    }


  }

}
