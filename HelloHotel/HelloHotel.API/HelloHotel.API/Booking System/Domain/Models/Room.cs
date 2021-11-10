namespace HelloHotel.API.Booking_System.Domain.Models
{
    public class Room
    {
        public int Id { get; set; }
        
        public int RoomNumber { get; set; }
        public string Available { get; set; }
        public string Client { get; set; }
        public int Phone { get; set; }
        public string DataIn { get; set; }
        public string DateOut { get; set; }
        public int Mont { get; set; }
    }
}