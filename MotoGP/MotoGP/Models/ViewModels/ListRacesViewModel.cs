using Microsoft.AspNetCore.Mvc.Rendering;

namespace MotoGP.Models.ViewModels
{
    public class ListRacesViewModel
    {
        public List<Race> Races;
        public SelectList SelectRaceList { get; set; }
        public int raceID { get; set; }
    }
}



