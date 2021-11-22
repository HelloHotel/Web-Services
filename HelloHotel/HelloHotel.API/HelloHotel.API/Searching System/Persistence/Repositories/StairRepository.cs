using System.Collections.Generic;
using System.Threading.Tasks;
using HelloHotel.API.Searching_System.Domain.Models;
using HelloHotel.API.Searching_System.Domain.Repositories;
using HelloHotel.API.Shared.Persistence.Context;
using HelloHotel.API.Shared.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;

namespace HelloHotel.API.Searching_System.Persistence.Repositories
{
    public class StairRepository : BaseRepository, IStairRepository
    {
        public StairRepository(AppDbContext context) : base(context)
        {
        }

        public async Task<IEnumerable<Stair>> ListAsync()
        {
            return await _context.Stairs.ToListAsync();
        }

        public async Task AddAsync(Stair stair)
        {
            await _context.Stairs.AddAsync(stair);
        }

        public async Task<Stair> FindByIdAsync(int id)
        {
            return await _context.Stairs.FindAsync(id);
        }

        public void Update(Stair stair)
        {
            _context.Stairs.Update(stair);
        }

        public void Remove(Stair stair)
        {
            _context.Stairs.Remove(stair);
        }
    }
}