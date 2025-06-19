using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MotoGP.Data;
using MotoGP.Models;
using MotoGP.Models.ViewModels;
using System.Net.NetworkInformation;

namespace MotoGP.Controllers
{
    public class ShopController : Controller
    {
        private readonly GPContext _context;
        public ShopController(GPContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult OrderTicket() {

            ViewData["Countries"] = new SelectList(_context.Countries.OrderBy(c => c.Name),"CountryID","Name");
            ViewData["Races"] = new SelectList(_context.Races.OrderBy(r => r.Name),"RaceID","Name");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind("TicketID", "CountryID", "RaceID", "Name", "Email", "Address", "Number", "OrderDate", "Paid")] Ticket ticket)
        {
            if (ModelState.IsValid)
            {
                ticket.OrderDate = DateTime.Now;
                ticket.Paid = false;

                _context.Add(ticket);
                _context.SaveChanges();
                return RedirectToAction("ConfirmOrder", new { id = ticket.TicketID });
            }

            return View(ticket);
        }
        public IActionResult ConfirmOrder(int id)
        {
            var ticket = _context.Tickets
                          .Include(t=>t.Race)
                         .SingleOrDefault(t => t.TicketID == id);
            return View(ticket);
        }

        public IActionResult ListTickets(int raceID=0)
        {
            var listTicketsVM = new ListTicketsViewModel();

            if (raceID != 0)
            {
               listTicketsVM.Tickets = _context.Tickets.Where(t=>t.RaceID==raceID).Include(t=>t.Country).Include(t=>t.Race).OrderByDescending(t => t.OrderDate).ToList();
            }
            else
            {
                listTicketsVM.Tickets = _context.Tickets.Include(t => t.Country).Include(t => t.Race).OrderByDescending(t => t.OrderDate).ToList();
            }
            listTicketsVM.Race =
                new SelectList(_context.Races.OrderBy(r => r.Name), "RaceID", "Name");
            listTicketsVM.raceID= raceID;

            

            return View(listTicketsVM);
        }
        public IActionResult EditTicket(int id)
        {
            var ticket = _context.Tickets.SingleOrDefault(t => t.TicketID == id);
            return View(ticket);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult EditTicket(int id, [Bind("TicketID","Paid")]Ticket ticket)
        {
          
                    _context.Tickets.Attach(ticket);
                    _context.Entry(ticket).Property(t => t.Paid).IsModified = true;
                    _context.SaveChanges();
               
                     return RedirectToAction("ListTickets");
       
        }
    }
}
