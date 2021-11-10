using HelloHotel.API.Booking_System.Domain.Models;
using HelloHotel.API.Domain.Services.Communication;

namespace HelloHotel.API.Booking_System.Domain.Services.Communication
{
    public class ClientResponse : BaseResponse<Client>
    {
        public ClientResponse(string message) : base(message)
        {
        }

        public ClientResponse(Client resource) : base(resource)
        {
        }
    }
}