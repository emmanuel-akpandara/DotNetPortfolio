using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Adventures.Domain.Models;
using Adventures.Infrastructure;

namespace Adventures.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TripsController : ControllerBase
    {
        private IUnitOfWork _uow;
        public TripsController(IUnitOfWork uow)
        {
            _uow = uow;
        }

        // GET: api/Trips
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Trip>>> GetTrips()
        {
            var trips = await _uow.TripRepository.GetAsync(includes: c => c.Bookings);
            return trips.ToList();

        }

        /*// GET: api/Trips/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Trip>> GetTrip(int id)
        {
          if (_context.Trips == null)
          {
              return NotFound();
          }
            var trip = await _context.Trips.FindAsync(id);

            if (trip == null)
            {
                return NotFound();
            }

            return trip;
        }

        // PUT: api/Trips/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTrip(int id, Trip trip)
        {
            if (id != trip.TripId)
            {
                return BadRequest();
            }

            _context.Entry(trip).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TripExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Trips
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Trip>> PostTrip(Trip trip)
        {
          if (_context.Trips == null)
          {
              return Problem("Entity set 'TravelContext.Trips'  is null.");
          }
            _context.Trips.Add(trip);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTrip", new { id = trip.TripId }, trip);
        }

        // DELETE: api/Trips/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTrip(int id)
        {
            if (_context.Trips == null)
            {
                return NotFound();
            }
            var trip = await _context.Trips.FindAsync(id);
            if (trip == null)
            {
                return NotFound();
            }

            _context.Trips.Remove(trip);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool TripExists(int id)
        {
            return (_context.Trips?.Any(e => e.TripId == id)).GetValueOrDefault();
        }*/
    }
}
