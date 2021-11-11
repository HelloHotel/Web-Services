using System.Collections.Generic;
using System.Threading.Tasks;
using HelloHotel.API.Hotel_System.Domain.Models;
using HelloHotel.API.Hotel_System.Domain.Services.Communication;

namespace HelloHotel.API.Hotel_System.Domain.Services
{
    public interface IEventService
    {
        Task<IEnumerable<Event>> ListAsync();
        Task<IEnumerable<Event>> ListByEmployeeIdAsync(int employeeId);
        Task<EventResponse> SaveAsync(Event @event);
        Task<EventResponse> UpdateAsync(int id, Event @event);
        Task<EventResponse> DeleteAsync(int id);
    }
}