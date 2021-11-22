﻿using AutoMapper;
using HelloHotel.API.Booking_System.Domain.Models;
using HelloHotel.API.Booking_System.Resources;
using HelloHotel.API.Hotel_System.Domain.Models;
using HelloHotel.API.Hotel_System.Resources;

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
            CreateMap<Room, RoomResources>();
            CreateMap<Hotel, HotelResources>();
        }
    }
}