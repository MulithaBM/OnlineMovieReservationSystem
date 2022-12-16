﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineMovieReservationSystem.Domain.Models
{
    public class Movie
    {
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public string Director { get; set; } = string.Empty;
        public string Cast { get; set; } = string.Empty;
        public string Type { get; set; } = string.Empty;
        public int Duration { get; set; }
        public string ReleaseDate { get; set; } = string.Empty;
    }
}
