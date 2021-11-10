using System.Collections.Generic;
using System.Threading.Tasks;
using HelloHotel.API.Hotel_System.Domain.Models;

namespace HelloHotel.API.Hotel_System.Domain.Repositories
{
    public interface IInventoryRepository
    {
        Task<IEnumerable<Inventory>> ListAsync();
        Task AddAsync(Inventory inventory);
        Task<Inventory> FindByIdAsync(int id);
        void Update(Inventory inventory);
        void Remove(Inventory inventory);
    }
}