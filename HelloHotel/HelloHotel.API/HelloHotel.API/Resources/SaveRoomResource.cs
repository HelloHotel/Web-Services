using System.ComponentModel.DataAnnotations;

namespace HelloHotel.API.Resources
{
    public class SaveRoomResource
    {
        [Required]
        public int RoomNumber { get; set; }
        
        [Required]
        public string Available { get; set; }
        
        [Required]
        public string Client { get; set; }
        
        [Required]
        public int Phone { get; set; }
        
        [Required]
        public string DataIn { get; set; }
        
        [Required]
        public string DateOut { get; set; }
        
        [Required]
        public int Mont { get; set; }

    }
}