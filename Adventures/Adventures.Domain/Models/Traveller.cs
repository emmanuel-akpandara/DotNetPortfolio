﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Adventures.Domain.Models
{
    public class Traveller
    {
        public int TravellerId { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string Email { get; set; }

        public ICollection<Booking>? Bookings { get; set; }
    }
}
