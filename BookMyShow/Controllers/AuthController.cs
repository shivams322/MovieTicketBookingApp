using AutoMapper;
using BookMyShow.Data;
using BookMyShow.DataModels;
using BookMyShow.DataModels.TableModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BookMyShow.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class AuthController : ControllerBase
  {
    public static Userdto user = new Userdto();

    private readonly IConfiguration Configuration;

    private readonly IMapper Mapper;

    private BookMyShowContext Context;

    public AuthController(IConfiguration configuration, BookMyShowContext context)
    {
      this.Configuration = configuration;
      this.Context=context;
    }

    [HttpPost("register")]
    public async Task<ActionResult<Userdto>> Register(Userdto request)
    {

      user.Email = request.Email;
      user.Password = request.Password;

      return Ok(user);
    }

    [HttpPost("login")]
    public async Task<ActionResult<string>> Login(Userdto request)
    {
      var users = this.Context.Db.Fetch<User>(string.Empty);
      string token = null;
      if (users.Any(user => user.Email == request.Email && user.Password == request.Password))
      {
        user.Email = request.Email;
        user.Password = request.Password;
        token = CreateToken(user);
      }
      else
      {
        return BadRequest("User not found");
      }

      return Ok(new { Token = token});
    }

    private string CreateToken(Userdto user)
    {
      List<Claim> claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, user.Email),
                new Claim(ClaimTypes.Role, "Admin")
            };

      var key = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes(
          Configuration.GetSection("AppSettings:Token").Value));

      var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);

      var token = new JwtSecurityToken(
          claims: claims,
          expires: DateTime.Now.AddDays(1),
          signingCredentials: creds);

      var jwt = new JwtSecurityTokenHandler().WriteToken(token);

      return jwt;
    }
  }
}
