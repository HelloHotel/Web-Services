using HelloHotel.API.Domain.Models;

namespace HelloHotel.API.Domain.Services.Communication
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