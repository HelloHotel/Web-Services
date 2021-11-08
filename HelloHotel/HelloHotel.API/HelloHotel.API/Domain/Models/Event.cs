namespace HelloHotel.API.Domain.Models
{
    public class Event
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Details { get; set; }
        public string Start { get; set; }
        public string End { get; set; }
        public string Color { get; set; }
        public bool Timed { get; set; }
        public int EmployeeId { get; set; }
        
        public Employee Employee { get; set; }
        
    }
}