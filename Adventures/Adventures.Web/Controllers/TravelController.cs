using Adventures.Domain.Models;
using Adventures.Domain.Models.ViewModels;
using Adventures.Infrastructure;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace Adventures.Web.Controllers
{
    public class TravelController : Controller
    {
        private readonly TravelContext _context;

        public TravelController(TravelContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var countries = _context.Countries.Include(c => c.Trips)
                            .ThenInclude(t => t.Bookings)
                            .ThenInclude(b => b.Traveller)
                            .OrderBy(c=>c.Name);
            return View(countries);
        }

        public IActionResult Create(int id)
        {
            var VM = new TripTravellerViewModel();
            VM.Trip = _context.Trips.SingleOrDefault(t => t.TripId == id);
            VM.TripId = id;
            VM.Travellers = new SelectList(_context.Travellers.OrderBy(t => t.Firstname), "TravellerId", "Firstname","Lastname");
            return View(VM);

        }



        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(int id, [Bind("TravellerId,TripId")] Booking booking)
        {
          
               
                // Add the new booking to the context
                _context.Bookings.Add(booking);

                // Save the changes to the database
                _context.SaveChanges();

                return RedirectToAction("Index", "Travel");

        }


    }
}
