using HelloHotel.API.Domain.Models;

namespace HelloHotel.API.Domain.Services.Communication
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