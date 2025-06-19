using Microsoft.AspNetCore.Mvc.Rendering;

namespace MotoGP.Models.ViewModels
{
    public class ListTicketsViewModel
    {
        public List <Ticket> Tickets;
        public SelectList Race { get; set; }

        public int raceID { get; set; }
    }
}
