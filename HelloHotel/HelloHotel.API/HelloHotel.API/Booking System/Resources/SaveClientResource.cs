using System.ComponentModel.DataAnnotations;

namespace HelloHotel.API.Booking_System.Resources
{
    public class SaveClientResource
    {
        [Required]
        [MaxLength(30)]
        public string Name { get; set; }
        
        [Required]
        [MaxLength(30)]
        public string LastName { get; set; }
        
        [Required]
        public int Dni { get; set; }
        
        [Required]
        public int Age { get; set; }
        
        [Required]
        public string Email { get; set; }
        
        [Required]
        public int Phone { get; set; }
        
        [Required]
        public int Room { get; set; }
    }
}