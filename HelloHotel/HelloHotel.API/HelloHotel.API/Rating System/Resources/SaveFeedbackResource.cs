using System.ComponentModel.DataAnnotations;

namespace HelloHotel.API.Rating_System.Resources
{
    public class SaveFeedbackResource
    {
        [Required]
        [MaxLength(50)]
        public string Name { get; set; }
        
        [Required]
        public string Text { get; set; }
        
        [Required]
        public int Stars { get; set; }
        
        [Required]
        public string Date { get; set; }
        
        [Required]
        public string Photo { get; set; }
    }
}