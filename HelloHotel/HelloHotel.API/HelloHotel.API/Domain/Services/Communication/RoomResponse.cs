using HelloHotel.API.Domain.Models;

namespace HelloHotel.API.Domain.Services.Communication
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