using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MotoGP.Data;
using MotoGP.Models;
using MotoGP.Models.ViewModels;

namespace MotoGP.Controllers
{
    public class InfoController : Controller
    {
        private readonly GPContext _context;
        public InfoController(GPContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult ListRaces()
        {
            var racesByMonth = _context.Races
            .OrderBy(r => r.Date);
         
            
            return View(racesByMonth);
        }
        public IActionResult ListTeams()
        {
            return View();
        }

        public IActionResult ListRiders()
        {
            var riders = _context.Riders
                          .Include(r => r.Country)
                          .OrderBy(r => r.Number);
            return View(riders);
        }

        public IActionResult BuildMap()
        {
            /*    List<Race> races = new List<Race>
            {
                new Race { RaceID = 1, X = 517, Y = 19, Name = "Assen" },
                new Race { RaceID = 2, X = 859, Y = 249, Name = "Losail Circuit" },
                new Race { RaceID = 3, X = 194, Y = 428, Name = "Autódromo Termas de Río Hondo" }
            };*/

            var races = _context.Races
                        .OrderBy(r => r.Name);

            return View(races);
        }

        public IActionResult ShowRace(int id)
        {
            var race = _context.Races
            .SingleOrDefault(r => r.RaceID ==
            id);
            return View(race);
        }
        public IActionResult SelectRace(int raceID = 0)
        {
            var listRacesVM = new ListRacesViewModel();
            if (raceID != 0)
            {
                listRacesVM.Races = _context.Races.Where(r=>r.RaceID== raceID).OrderBy(r=>r.Name).ToList(); 
            }
            else
            {
                listRacesVM.Races = _context.Races.OrderBy(r => r.Name).ToList();
            }

            listRacesVM.SelectRaceList =
                new SelectList(_context.Races.OrderBy(r => r.Name),
                                "RaceID","Name");
            listRacesVM.raceID = raceID;
            return View(listRacesVM);
        }
    }
}
