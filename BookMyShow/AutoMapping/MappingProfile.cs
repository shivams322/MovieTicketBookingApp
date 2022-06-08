using AutoMapper;
using BookMyShow.DataModels;
using BookMyShow.DataModels.TableModels;
using BookMyShow.Models.CoreModels;

namespace BookMyShow.Models
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<MovieList, MovieModel>()
                .ForMember(dest => dest.Genre, m => m.MapFrom(src => src.Genre.Split(',', System.StringSplitOptions.RemoveEmptyEntries).ToList()));
            CreateMap<User, UserModel>().ReverseMap();
            CreateMap<Cinema, CinemaModel>().ReverseMap();
            CreateMap<ShowSeat, ShowSeatModel>().ReverseMap();
            CreateMap<Booking, BookingModel>().ReverseMap();
            CreateMap<ShowList, ShowModel>().ReverseMap();
            CreateMap<Ticket, TicketModel>().ReverseMap();
            CreateMap<User, Userdto>().ReverseMap();
        }
    }
}
