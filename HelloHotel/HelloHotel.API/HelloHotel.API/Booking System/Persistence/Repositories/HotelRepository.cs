using System.Collections.Generic;
using System.Threading.Tasks;
using HelloHotel.API.Booking_System.Domain.Models;
using HelloHotel.API.Booking_System.Domain.Repositories;
using HelloHotel.API.Shared.Persistence.Context;
using HelloHotel.API.Shared.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;

namespace HelloHotel.API.Booking_System.Persistence.Repositories
{
    public class HotelRepository : BaseRepository, IHotelRepository
    {
        public HotelRepository(AppDbContext context) : base(context)
        {
        }
        
        public async Task<IEnumerable<Hotel>> ListAsync()
        {
            return await _context.Hotels.ToListAsync();
        }
        
        public async Task AddAsync(Hotel client)
        {
            await _context.Hotels.AddAsync(client);
        }

        public async Task<Hotel> FindByIdAsync(int id)
        {
            return await _context.Hotels.FindAsync(id);
        }

        public void Update(Hotel hotel)
        {
            _context.Hotels.Update(hotel);
        }

        public void Remove(Hotel hotel)
        {
            _context.Hotels.Remove(hotel);
        }
    }
}