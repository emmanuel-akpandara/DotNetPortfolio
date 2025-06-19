using Microsoft.AspNetCore.Mvc;
using MvcMovie.Data;
using MvcMovie.Models;
using System.Data;
using System.Linq.Expressions;

namespace MvcMovie.Controllers
{
    public class RatingsController : Controller
    {
        private readonly MovieContext _context;
        public RatingsController(MovieContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Create()
        {
            return View();
        }

        public IActionResult List()
        {
            var ratings = _context.Ratings.OrderBy(r => r.Name);
            return View(ratings);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind("RatingID,Code,Name")] Rating rating)
        {
            if (ModelState.IsValid)
            {
                _context.Add(rating);
                _context.SaveChanges();
                return RedirectToAction("List");
            }
            return View(rating);
        }

        public IActionResult Edit(int id)
        {
            var rating = _context.Ratings
                            .SingleOrDefault(r => r.RatingID == id);
            return View(rating);

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit([Bind("RatingID,Code,Name")] Rating rating)
        {
            if (ModelState.IsValid)
            {
                try { _context.Update(rating);
                    _context.SaveChanges();
                    }
                catch (DBConcurrencyException)
                {
                    throw;
                }
                return RedirectToAction("List");
            }
            
            return View(rating);
        }

        public IActionResult Delete(int id)
        {
            var rating = _context.Ratings.SingleOrDefault(r => r.RatingID == id);
            _context.Ratings.Remove(rating);
            _context.SaveChanges();
            return RedirectToAction("List");
        }
    }
}
