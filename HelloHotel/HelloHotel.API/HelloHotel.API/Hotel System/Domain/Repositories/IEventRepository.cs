using System.Collections.Generic;
using System.Threading.Tasks;
using HelloHotel.API.Hotel_System.Domain.Models;

namespace HelloHotel.API.Hotel_System.Domain.Repositories
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