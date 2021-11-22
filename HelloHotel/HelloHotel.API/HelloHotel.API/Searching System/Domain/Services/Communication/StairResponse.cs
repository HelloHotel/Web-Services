using HelloHotel.API.Searching_System.Domain.Models;
using HelloHotel.API.Shared.Domain.Services.Communication;

namespace HelloHotel.API.Searching_System.Domain.Services.Communication
{
    public class StairResponse : BaseResponse<Stair>
    {
        public StairResponse(string message) : base(message)
        {
        }

        public StairResponse(Stair resource) : base(resource)
        {
        }
    }
}