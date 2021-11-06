using AutoMapper;
using HelloHotel.API.Domain.Models;
using HelloHotel.API.Resources;

namespace HelloHotel.API.Mapping
{
    public class ModelToResourceProfile : Profile
    {
        public ModelToResourceProfile()
        {
            CreateMap<Employee, EmployeeResources>();
            CreateMap<Event, EventResources>();
            CreateMap<Client, ClientResources>();
            CreateMap<Inventory, InventoryResources>();
        }
    }
}