using HelloHotel.API.Domain.Models;

namespace HelloHotel.API.Domain.Services.Communication
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