using System.Collections.Generic;
using HelloHotel.API.Booking_System.Domain.Models;

namespace HelloHotel.API.Searching_System.Domain.Models
{
    public class Stair
    {
        public int Id { get; set; }
        public int StairNumber { get; set; }
        public int Cost { get; set; }
        public int RoomId { get; set; }
    }
}