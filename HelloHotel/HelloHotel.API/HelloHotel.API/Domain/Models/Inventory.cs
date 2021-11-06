namespace HelloHotel.API.Domain.Models
{
    public class Inventory
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Stock { get; set; }
        public int MontUnit { get; set; }
        public string Supplier { get; set; }
    }
}