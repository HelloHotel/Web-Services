using System.ComponentModel.DataAnnotations;

namespace HelloHotel.API.Hotel_System.Resources
{
    public class SaveEventResource
    {
        [Required]
        [MaxLength(30)]
        public string Name { get; set; }
        
        [Required]
        [MaxLength(50)]
        public string Details { get; set; }
        
        [Required]
        [MaxLength(50)]
        public string Start { get; set; }
        
        [Required]
        [MaxLength(50)]
        public string End { get; set; }
        
        [Required]
        [MaxLength(10)]
        public string Color { get; set; }
        
        [Required]
        public bool Timed { get; set; }
        
        [Required]
        public int EmployeeId { get; set; }
    }
}