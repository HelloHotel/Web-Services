﻿using AutoMapper;
using HelloHotel.API.Booking_System.Domain.Models;
using HelloHotel.API.Booking_System.Resources;
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
            CreateMap<SaveInventoryResource, Inventory>();
            CreateMap<SaveRoomResource, Room>();
            CreateMap<SaveHotelResource, Hotel>();
        }
    }
}