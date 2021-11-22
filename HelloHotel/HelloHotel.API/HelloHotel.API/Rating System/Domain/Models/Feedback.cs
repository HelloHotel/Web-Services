namespace HelloHotel.API.Rating_System.Domain.Models
{
    public class Feedback
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Text { get; set; }
        public int Stars { get; set; }
        public string Date { get; set; }
        public string Photo { get; set; }
    }
}