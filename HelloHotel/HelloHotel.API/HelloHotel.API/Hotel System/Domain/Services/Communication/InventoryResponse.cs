using HelloHotel.API.Hotel_System.Domain.Models;
using HelloHotel.API.Shared.Domain.Services.Communication;

namespace HelloHotel.API.Hotel_System.Domain.Services.Communication
{
    public class InventoryResponse : BaseResponse<Inventory>
    {
        public InventoryResponse(string message) : base(message)
        {
        }

        public InventoryResponse(Inventory resource) : base(resource)
        {
        }
    }
}