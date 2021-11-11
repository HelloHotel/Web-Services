using System.ComponentModel.DataAnnotations;

namespace HelloHotel.API.Booking_System.Resources
{
    public class SaveHotelResource
    {
        [Required]
        [MaxLength(30)]
        public string Name { get; set; }
        
        [Required]
        public int Stars { get; set; }
        
        [Required]
        [MaxLength(150)]
        public string Description { get; set; }
        
        [Required]
        public string City { get; set; }
        
        [Required]
        public string Photo { get; set; }
    }
}