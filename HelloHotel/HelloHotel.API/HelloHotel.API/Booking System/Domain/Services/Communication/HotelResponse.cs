using HelloHotel.API.Booking_System.Domain.Models;
using HelloHotel.API.Shared.Domain.Services.Communication;

namespace HelloHotel.API.Booking_System.Domain.Services.Communication
{
    public class HotelResponse : BaseResponse<Hotel>
    {
        public HotelResponse(string message) : base(message)
        {
        }

        public HotelResponse(Hotel resource) : base(resource)
        {
        }
    }
}