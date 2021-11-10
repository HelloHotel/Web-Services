using System.Collections.Generic;

namespace HelloHotel.API.Hotel_System.Domain.Models
{
    public class Employee
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public int Dni { get; set; }
        public int Age { get; set; }
        public string Email { get; set; }
        public int Phone { get; set; }
        public string Workstation { get; set; }
        
        public IList<Event> Events { get; set; }
    }
}