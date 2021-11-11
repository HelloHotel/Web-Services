using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using HelloHotel.API.Booking_System.Domain.Models;
using HelloHotel.API.Booking_System.Domain.Repositories;
using HelloHotel.API.Booking_System.Domain.Services;
using HelloHotel.API.Booking_System.Domain.Services.Communication;

namespace HelloHotel.API.Booking_System.Services
{
    public class HotelService : IHotelService
    {
        private readonly IHotelRepository _hotelRepository;

        public HotelService(IHotelRepository hotelRepository)
        {
            _hotelRepository = hotelRepository;
        }

        public async Task<IEnumerable<Hotel>> ListAsync()
        {
            return await _hotelRepository.ListAsync();
        }

        public async Task<HotelResponse> SaveAsync(Hotel hotel)
        {
            try
            {
                await _hotelRepository.AddAsync(hotel);
                return new HotelResponse(hotel);
            }
            catch(Exception e)
            {
                return new HotelResponse($"An error occurred while saving Category: {e.Message}");
            }
        }

        public async Task<HotelResponse> UpdateAsync(int id, Hotel hotel)
        {
            var existingCategory = await _hotelRepository.FindByIdAsync(id);

            if (existingCategory == null)
                return new HotelResponse("Category not found.");
            
            existingCategory.Name = hotel.Name;

            try
            {
                _hotelRepository.Update(existingCategory);


                return new HotelResponse(existingCategory);
            }
            catch (Exception e)
            {
                return new HotelResponse($"An error ocurred wile updating the category: {e.Message}");
            }
        }

        public async Task<HotelResponse> DeleteAsync(int id)
        {
            var existingCategory = await _hotelRepository.FindByIdAsync(id);

            if (existingCategory == null)
                return new HotelResponse("Hotel not found");

            try
            {
                _hotelRepository.Remove(existingCategory);

                return new HotelResponse(existingCategory);
            }
            catch (Exception e)
            {
                return new HotelResponse($"An error occurred while deleting the hotel:{e.Message}");
            }
        }
    }
}