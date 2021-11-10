using HelloHotel.API.Hotel_System.Domain.Models;
using HelloHotel.API.Domain.Services.Communication;

namespace HelloHotel.API.Hotel_System.Domain.Services.Communication
{
    public class EventResponse : BaseResponse<Event>
    {
        public EventResponse(string message) : base(message)
        {
        }

        public EventResponse(Event resource) : base(resource)
        {
        }
    }
}