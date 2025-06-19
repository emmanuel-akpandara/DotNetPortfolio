using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace Adventures.Domain.Models.ViewModels
{
    public class TripTravellerViewModel
    {
        public Trip Trip;
        public SelectList Travellers { get; set; }
        public int TripId { get; set; }
        public int TravellerId { get; set; }

    }

   
}
