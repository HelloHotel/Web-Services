using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HelloHotel.API.Domain.Models;
using HelloHotel.API.Domain.Repositories;
using HelloHotel.API.Persistence.Context;
using Microsoft.EntityFrameworkCore;

namespace HelloHotel.API.Persistence.Repositories
{
    public class EventRepository : BaseRepository, IEventRepository
    {
        public EventRepository(AppDbContext context) : base(context)
        {
        }


        public async Task<IEnumerable<Event>> ListAsync()
        {
            return await _context.Events
                .Include(p => p.Employee)
                .ToListAsync();
        }

        public async Task AddAsync(Event @event)
        {
            await _context.Events.AddAsync(@event);
        }

        public async Task<Event> FindByIdAsync(int id)
        {
            return await _context.Events
                .Include(p => p.Employee)
                .FirstOrDefaultAsync(p => p.Id == id);
        }

        public async Task<IEnumerable<Event>> FindByEmployeeId(int id)
        {
            return await _context.Events
                .Where(p => p.EmployeeId == id)
                .Include(p => p.Employee)
                .ToListAsync();
        }

        public void Update(Event @event)
        {
            _context.Events.Remove(@event);
        }

        public void Remove(Event @event)
        {
            _context.Events.Update(@event);
        }
    }
}