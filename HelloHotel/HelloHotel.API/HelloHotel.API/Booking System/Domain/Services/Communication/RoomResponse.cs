using HelloHotel.API.Booking_System.Domain.Models;
using HelloHotel.API.Shared.Domain.Services.Communication;

namespace HelloHotel.API.Booking_System.Domain.Services.Communication
{
    public class RoomResponse : BaseResponse<Room>
    {
        public RoomResponse(string message) : base(message)
        {
        }

        public RoomResponse(Room resource) : base(resource)
        {
        }
    }
}