using System.Collections.Generic;
using System.Threading.Tasks;
using HelloHotel.API.Booking_System.Domain.Models;

namespace HelloHotel.API.Booking_System.Domain.Repositories
{
    public interface IRoomRepository
    {
        Task<IEnumerable<Room>> ListAsync();
        Task AddAsync(Room room);
        Task<Room> FindByIdAsync(int id);
        void Update(Room room);
        void Remove(Room room);
    }
}