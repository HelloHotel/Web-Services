using HelloHotel.API.Domain.Models;

namespace HelloHotel.API.Domain.Services.Communication
{
    public class EventResponse : BaseResponse<Event>
    {
        public EventResponse(string message) : base(message)
        {
        }

        protected EventResponse(Event resource) : base(resource)
        {
        }
    }
}