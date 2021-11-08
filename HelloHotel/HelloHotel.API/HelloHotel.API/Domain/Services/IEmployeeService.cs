using System.Collections.Generic;
using System.Threading.Tasks;
using HelloHotel.API.Domain.Models;
using HelloHotel.API.Domain.Services.Communication;

namespace HelloHotel.API.Domain.Services
{
    public interface IEmployeeService
    {
        Task<IEnumerable<Employee>> ListAsync();
        Task<EmployeeResponse> SaveAsync(Employee employee);
        Task<EmployeeResponse> UpdateAsync(int id, Employee employee);
        Task<EmployeeResponse> DeleteAsync(int id);
    }
}