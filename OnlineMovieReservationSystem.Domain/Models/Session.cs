using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineMovieReservationSystem.Domain.Models
{
    public class Session
    {
        public int Id { get; set; }
        public Movie Movie { get; set; }
        public Venue Venue { get; set; }
    }
}
