namespace HelloHotel.API.Booking_System.Domain.Models
{
    public class Hotel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Stars { get; set; }
        public string Description { get; set; }
        public string City { get; set; }
        public string Photo { get; set; }
    }
}