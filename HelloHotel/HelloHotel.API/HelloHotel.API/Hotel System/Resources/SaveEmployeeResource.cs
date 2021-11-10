using System.ComponentModel.DataAnnotations;

namespace HelloHotel.API.Hotel_System.Resources
{
    public class SaveEmployeeResource
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
        public string Workstation { get; set; }

    }
}