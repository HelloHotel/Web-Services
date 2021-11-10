using System.Collections.Generic;
using System.Threading.Tasks;
using HelloHotel.API.Hotel_System.Domain.Models;
using HelloHotel.API.Hotel_System.Domain.Services.Communication;

namespace HelloHotel.API.Hotel_System.Domain.Services
{
    public interface IInventoryService
    {
        Task<IEnumerable<Inventory>> ListAsync();
        Task<InventoryResponse> SaveAsync(Inventory inventory);
        Task<InventoryResponse> UpdateAsync(int id, Inventory inventory);
        Task<InventoryResponse> DeleteAsync(int id);
    }
}