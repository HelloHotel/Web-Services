using System.Collections.Generic;
using System.Threading.Tasks;
using HelloHotel.API.Domain.Models;

namespace HelloHotel.API.Domain.Repositories
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