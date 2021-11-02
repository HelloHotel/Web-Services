using System.Collections.Generic;
using System.Threading.Tasks;
using HelloHotel.API.Domain.Models;

namespace HelloHotel.API.Domain.Repositories
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