using System.Collections.Generic;
using System.Threading.Tasks;
using HelloHotel.API.Domain.Models;

namespace HelloHotel.API.Domain.Repositories
{
    public interface IEventRepository
    {
        Task<IEnumerable<Event>> ListAsync();
        Task AddAsync(Event @event);
        Task<Event> FindByIdAsync(int id);
        Task<IEnumerable<Event>> FindByEmployeeId(int id);
        void Update(Event @event);
        void Remove(Event @event);
    }
}