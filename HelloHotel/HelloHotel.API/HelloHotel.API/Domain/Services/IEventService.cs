using System.Collections.Generic;
using System.Threading.Tasks;
using HelloHotel.API.Domain.Models;
using HelloHotel.API.Domain.Services.Communication;

namespace HelloHotel.API.Domain.Services
{
    public interface IEventService
    {
        Task<IEnumerable<Event>> ListAsync();
        Task<IEnumerable<Event>> ListByIdAsync();
        Task<EventResponse> SaveAsync(Event @event);
        Task<EventResponse> UpdateAsync(int id, Event @event);
        Task<EventResponse> DeleteAsync(int id);
    }
}