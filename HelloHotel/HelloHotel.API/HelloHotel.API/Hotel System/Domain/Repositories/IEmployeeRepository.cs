using System.Collections.Generic;
using System.Threading.Tasks;
using HelloHotel.API.Hotel_System.Domain.Models;

namespace HelloHotel.API.Hotel_System.Domain.Repositories
{
    public interface IEmployeeRepository
    {
        Task<IEnumerable<Employee>> ListAsync();
        Task AddAsync(Employee employee);
        Task<Employee> FindByIdAsync(int id);
        void Update(Employee employee);
        void Remove(Employee employee);
    }
}
