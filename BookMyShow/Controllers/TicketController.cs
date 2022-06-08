using BookMyShow.DataModels;
using BookMyShow.Models;
using BookMyShow.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SimpleInjector;

namespace BookMyShow.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  [Authorize]
  public class TicketController : ControllerBase
  {
    public ITicketService TicketService;

    public TicketController(Container container)
    {
      TicketService = container.GetInstance<ITicketService>();
    }

    [HttpPost("bookTicket")]
    public bool TicketBooking(BookingModel ticket)
    {
      return TicketService.BookTicket(ticket);
    }

    [HttpGet("ticket/{id}/{showId}")]
    public List<TicketModel> ShowTicket(int id,int showId)
    {
      return TicketService.GetTicket(id,showId);
    }

    [HttpGet("alltickets/{userId}")]
    public List<TicketModel> GetAllTickets(int userId)
    {
      return TicketService.GetAllTickets(userId);
    }

    [HttpGet("seatstatus/{showId}")]
    public List<ShowSeatModel> ShowAllSeats(int showId)
    {
      return TicketService.ShowAllSeats(showId);
    }
  }
}
