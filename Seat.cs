using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScotRail
{
    internal class Seat
    {
        public int SeatNumber { get; set; } 
        public Customer Occupant {  get; set; }
        public Seat(int seatNumber)
        {
            SeatNumber = seatNumber;
        }
    }
}
