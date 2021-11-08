namespace HelloHotel.API.Domain.Models
{
    public class Client
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public int Dni { get; set; }
        public int Age { get; set; }
        public string Email { get; set; }
        public int Phone { get; set; }
        public int Room { get; set; }
    }
}