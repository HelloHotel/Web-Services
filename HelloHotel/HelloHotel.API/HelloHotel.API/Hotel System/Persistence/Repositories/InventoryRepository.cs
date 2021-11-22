using System.Collections.Generic;
using System.Threading.Tasks;
using HelloHotel.API.Hotel_System.Domain.Models;
using HelloHotel.API.Hotel_System.Domain.Repositories;
using HelloHotel.API.Shared.Persistence.Context;
using HelloHotel.API.Shared.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;

namespace HelloHotel.API.Hotel_System.Persistence.Repositories
{
    public class InventoryRepository : BaseRepository, IInventoryRepository
    {
        public InventoryRepository(AppDbContext context) : base(context)
        {
        }

        public async Task<IEnumerable<Inventory>> ListAsync()
        {
            return await _context.Inventories.ToListAsync();
        }

        public async Task AddAsync(Inventory inventory)
        {
            await _context.Inventories.AddAsync(inventory);
        }

        public async Task<Inventory> FindByIdAsync(int id)
        {
            return await _context.Inventories.FindAsync(id);
        }

        public void Update(Inventory inventory)
        {
            _context.Inventories.Update(inventory);
        }

        public void Remove(Inventory inventory)
        {
            _context.Inventories.Remove(inventory);
        }
    }
}