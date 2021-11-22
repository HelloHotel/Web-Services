using AutoMapper;
using HelloHotel.API.Booking_System.Domain.Models;
using HelloHotel.API.Booking_System.Resources;
using HelloHotel.API.Hotel_System.Domain.Models;
using HelloHotel.API.Hotel_System.Resources;
using HelloHotel.API.Searching_System.Domain.Models;
using HelloHotel.API.Searching_System.Resources;

namespace HelloHotel.API.Shared.Mapping
{
    public class ModelToResourceProfile : Profile
    {
        public ModelToResourceProfile()
        {
            CreateMap<Employee, EmployeeResources>();
            CreateMap<Event, EventResources>();
            CreateMap<Client, ClientResources>();
            CreateMap<Inventory, InventoryResources>();
            CreateMap<Room, RoomResources>();
            CreateMap<Hotel, HotelResources>();
            CreateMap<Stair, StairResource>();
        }
    }
}