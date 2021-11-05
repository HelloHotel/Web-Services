using AutoMapper;
using HelloHotel.API.Domain.Models;
using HelloHotel.API.Resources;

namespace HelloHotel.API.Mapping
{
    public class ResourceToModelProfile : Profile
    {
        public ResourceToModelProfile()
        {
            CreateMap<SaveEmployeeResource, Employee>();
            CreateMap<SaveEventResource, Event>();
            CreateMap<SaveClientResource, Client>();
        }
    }
}