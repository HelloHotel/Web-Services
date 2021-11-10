using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using HelloHotel.API.Booking_System.Domain.Models;
using HelloHotel.API.Booking_System.Domain.Repositories;
using HelloHotel.API.Booking_System.Domain.Services;
using HelloHotel.API.Booking_System.Domain.Services.Communication;

namespace HelloHotel.API.Booking_System.Services
{
    public class RoomService : IRoomService
    {
        private readonly IRoomRepository _roomRepository;

        public RoomService(IRoomRepository roomRepository)
        {
            _roomRepository = roomRepository;
        }

        public async Task<IEnumerable<Room>> ListAsync()
        {
            return await _roomRepository.ListAsync();
        }

        public async Task<RoomResponse> SaveAsync(Room room)
        {
            try
            {
                await _roomRepository.AddAsync(room);
                return new RoomResponse(room);
            }
            catch(Exception e)
            {
                return new RoomResponse($"An error occurred while saving Category: {e.Message}");
            }
        }

        public async Task<RoomResponse> UpdateAsync(int id, Room room)
        {
            var existingCategory = await _roomRepository.FindByIdAsync(id);

            if (existingCategory == null)
                return new RoomResponse("Category not found.");
            
            existingCategory.RoomNumber = room.RoomNumber;

            try
            {
                _roomRepository.Update(existingCategory);


                return new RoomResponse(existingCategory);
            }
            catch (Exception e)
            {
                return new RoomResponse($"An error occurred while updating the category: {e.Message}");
            }
        }

        public async Task<RoomResponse> DeleteAsync(int id)
        {
            var existingCategory = await _roomRepository.FindByIdAsync(id);

            if (existingCategory == null)
                return new RoomResponse("Room not found");

            try
            {
                _roomRepository.Remove(existingCategory);

                return new RoomResponse(existingCategory);
            }
            catch (Exception e)
            {
                return new RoomResponse($"An error occurred while deleting the employee:{e.Message}");
            }
        }
    }
}