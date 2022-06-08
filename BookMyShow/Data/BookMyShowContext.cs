using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using PetaPoco;
using System.Data;

namespace BookMyShow.Data
{
    public class BookMyShowContext : DbContext
    {
        public IDatabase Db { get; }

        public BookMyShowContext(DbContextOptions<BookMyShowContext> options, IConfiguration configuration)
            : base(options)
        {
            var db = configuration["ConnectionStrings"];
            this.Db = new PetaPoco.Database(configuration.GetConnectionString("BookMyShowContext"), "System.Data.SqlClient");
             
        }
        //.GetConnectionString("BookMyShowContext"), "System.Data.SqlClient"
    }
}
