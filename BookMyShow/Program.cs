using Microsoft.EntityFrameworkCore;
using BookMyShow.Data;
using BookMyShow.Models;
using BookMyShow.Services;
using SimpleInjector;
using SimpleInjector.Lifestyles;
using Microsoft.IdentityModel.Tokens;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.DependencyInjection;
using System.Configuration;
using System.Text;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<BookMyShowContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("BookMyShowContext") ?? throw new InvalidOperationException("Connection string 'BookMyShowContext' not found.")));


builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
      options.TokenValidationParameters = new TokenValidationParameters
      {
        ValidateIssuerSigningKey = true,
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8
              .GetBytes(builder.Configuration.GetSection("AppSettings:Token").Value)),
        ValidateIssuer = false,
        ValidateAudience = false
      };
    });

builder.Services.AddCors();
builder.Services.AddAutoMapper(typeof(MappingProfile));

builder.Services.AddMvcCore();
var container = new Container();
container.Options.DefaultScopedLifestyle = new AsyncScopedLifestyle();
builder.Services.AddSimpleInjector(container, options =>
{
    options.AddAspNetCore().AddControllerActivation();
});
InitializeContainer();

void InitializeContainer()
{
    container.Register<IMovieService, MovieService>(Lifestyle.Scoped);
    container.Register<IShowService, ShowService>(Lifestyle.Scoped);
    container.Register<IUserService, UserService>(Lifestyle.Scoped);
    container.Register<ITicketService,TicketService>(Lifestyle.Scoped);
}

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options => {
  options.AddSecurityDefinition("oauth2", new OpenApiSecurityScheme
  {
    Description = "Standard Authorization header using the Bearer scheme (\"bearer {token}\")",
    In = ParameterLocation.Header,
    Name = "Authorization",
    Type = SecuritySchemeType.ApiKey
  });

  options.OperationFilter<Swashbuckle.AspNetCore.Filters.SecurityRequirementsOperationFilter>();
});

var app = builder.Build();

app.Services.UseSimpleInjector(container);
container.Verify();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseCors(x => x
            .AllowAnyOrigin()
            .AllowAnyMethod()
            .AllowAnyHeader());

app.UseHttpsRedirection();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();


app.Run();
