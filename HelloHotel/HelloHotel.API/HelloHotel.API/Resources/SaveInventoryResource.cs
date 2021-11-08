using System.ComponentModel.DataAnnotations;

namespace HelloHotel.API.Resources
{
    public class SaveInventoryResource
    {
        [Required]
        [MaxLength(30)]
        public string Name { get; set; }
        
        [Required]
        public int Stock { get; set; }
        
        [Required]
        public int MontUnit { get; set; }
        
        [Required]
        public string Supplier { get; set; }
    }
}