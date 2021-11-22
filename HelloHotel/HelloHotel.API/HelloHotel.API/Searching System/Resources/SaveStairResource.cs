using System.ComponentModel.DataAnnotations;

namespace HelloHotel.API.Searching_System.Resources
{
    public class SaveStairResource
    {
        [Required]
        public int StairNumber { get; set; }
        
        [Required]
        public int Cost { get; set; }
        
        [Required]
        public int RoomId { get; set; }
    }
}