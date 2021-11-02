namespace HelloHotel.API.Resources
{
    public class EventResources
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Details { get; set; }
        public string Start { get; set; }
        public string End { get; set; }
        public string Color { get; set; }
        public bool Timed { get; set; }
        public int EmployeeId { get; set; }
        
        public EmployeeResources Employee { get; set; }
    }
}