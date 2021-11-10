using HelloHotel.API.Hotel_System.Domain.Models;
using HelloHotel.API.Domain.Services.Communication;

namespace HelloHotel.API.Hotel_System.Domain.Services.Communication
{
    public class EmployeeResponse : BaseResponse<Employee>
    {
        public EmployeeResponse(string message) : base(message)
        {
        }

        public EmployeeResponse(Employee resource) : base(resource)
        {
        }
    }
}