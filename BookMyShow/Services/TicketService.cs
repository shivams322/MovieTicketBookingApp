using BookMyShow.Models;
using BookMyShow.DataModels;
using AutoMapper;
using BookMyShow.Enums;
using BookMyShow.Data;

namespace BookMyShow.Services
{
    public class TicketService: ITicketService
    {
        private BookMyShowContext Context;

        private readonly IMapper Mapper;

        private int BookingId;

        public TicketService(IMapper mapper,BookMyShowContext context)
        {
            this.Mapper = mapper;
            this.Context = context;
        }

        public bool BookTicket(BookingModel ticket)
        {
            var bookticket = this.Mapper.Map<BookingModel,Booking>(ticket);
            for(int i = 0; i < ticket.SeatNumbers.Count; i++)
            {
                if(this.Context.Db.Exists<ShowSeat>("Where ShowId=@0 AND SeatNumber=@1", ticket.ShowId, ticket.SeatNumbers[i]))
                {
                    return false;
                }
            }
            int bookedTicketId = Convert.ToInt32(this.Context.Db.Insert(bookticket));
            var result = this.Context.Db.FirstOrDefault<ShowList>("where [id]= @0",ticket.ShowId);
            int cinemaId = result.CinemaId;
            
            for (int i = 0; i < ticket.SeatNumbers.Count; i++)
            { 
                this.Context.Db.Insert(new ShowSeat { Price=200, Status = "Acquired",
                  SeatNumber = ticket.SeatNumbers[i], ShowId = ticket.ShowId,
                  BookingId = bookedTicketId, CinemaId = cinemaId });
            }
            return true;
        }

        public List<TicketModel> GetTicket(int id,int showId)
        {
            var ticket = this.Context.Db.Fetch<Ticket>("WHERE Id= @0 AND ShowId=@1",id,showId);
            if (ticket.Count == 0)
            {
                throw new Exception("No such Ticket Booked");
            }
            return this.Mapper.Map<IList<Ticket>, IList<TicketModel>>(ticket).ToList();
           
        }

        public List<TicketModel> GetAllTickets(int id)
        {
          var ticket = this.Context.Db.Fetch<Ticket>("WHERE Id= @0", id);
          return this.Mapper.Map<IList<Ticket>, IList<TicketModel>>(ticket).ToList();

        }
        public List<ShowSeatModel> ShowAllSeats(int showId)
            {
                var seats = this.Context.Db.Fetch<ShowSeat>("WHERE ShowId = @0",showId);
                return this.Mapper.Map<IList<ShowSeat>, IList<ShowSeatModel>>(seats).ToList();
            }
        }
}
