using System.Collections.Generic;
using System.Threading.Tasks;
using HelloHotel.API.Booking_System.Domain.Models;
using HelloHotel.API.Booking_System.Domain.Repositories;
using HelloHotel.API.Shared.Persistence.Context;
using HelloHotel.API.Shared.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;

namespace HelloHotel.API.Booking_System.Persistence.Repositories
{
    public class RoomRepository : BaseRepository, IRoomRepository
    {
        public RoomRepository(AppDbContext context) : base(context)
        {
        }
        
        public async Task<IEnumerable<Room>> ListAsync()
        {
            return await _context.Rooms.ToListAsync();
        }
        
        public async Task AddAsync(Room room)
        {
            await _context.Rooms.AddAsync(room);
        }

        public async Task<Room> FindByIdAsync(int id)
        {
            return await _context.Rooms.FindAsync(id);
        }

        public void Update(Room room)
        {
            _context.Rooms.Update(room);
        }

        public void Remove(Room room)
        {
            _context.Rooms.Remove(room);
        }
    }
}