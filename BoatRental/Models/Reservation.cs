using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BoatRental.Models
{
    public class Reservation
    {
        public int ReservationID { get; set; }
        public int UserID { get; set; }
        public int BoatID { get; set; }
        public User User { get; set; }
        public Boat Boat { get; set; }
    }
}
