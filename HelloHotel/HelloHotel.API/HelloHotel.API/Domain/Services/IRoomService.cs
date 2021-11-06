using System.Collections.Generic;
using System.Threading.Tasks;
using HelloHotel.API.Domain.Models;
using HelloHotel.API.Domain.Services.Communication;

namespace HelloHotel.API.Domain.Services
{
    public interface IRoomService
    {
        Task<IEnumerable<Room>> ListAsync();
        Task<RoomResponse> SaveAsync(Room room);
        Task<RoomResponse> UpdateAsync(int id, Room room);
        Task<RoomResponse> DeleteAsync(int id);
    }
}