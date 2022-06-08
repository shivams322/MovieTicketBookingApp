using BookMyShow.Models;

namespace BookMyShow.Services
{
    public interface ITicketService
    {
        bool BookTicket(BookingModel ticket);

        List<TicketModel> GetTicket(int id,int showId);

        List<TicketModel> GetAllTickets(int id);

        List<ShowSeatModel> ShowAllSeats(int showId);
    }
}
