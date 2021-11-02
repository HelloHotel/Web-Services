using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using HelloHotel.API.Domain.Models;
using HelloHotel.API.Domain.Repositories;
using HelloHotel.API.Domain.Services;
using HelloHotel.API.Domain.Services.Communication;

namespace HelloHotel.API.Services
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IEmployeeRepository _employeeRepository;

        public EmployeeService(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }

        public async Task<IEnumerable<Employee>> ListAsync()
        {
            return await _employeeRepository.ListAsync();
        }

        public async Task<EmployeeResponse> SaveAsync(Employee employee)
        {
            try
            {
                await _employeeRepository.AddAsync(employee);
                return new EmployeeResponse(employee);
            }
            catch(Exception e)
            {
                return new EmployeeResponse($"An error occurred while saving Category: {e.Message}");
            }
        }

        public async Task<EmployeeResponse> UpdateAsync(int id, Employee employee)
        {
            var existingCategory = await _employeeRepository.FindByIdAsync(id);

            if (existingCategory == null)
                return new EmployeeResponse("Category not found.");
            
            existingCategory.Name = employee.Name;

            try
            {
                _employeeRepository.Update(existingCategory);


                return new EmployeeResponse(existingCategory);
            }
            catch (Exception e)
            {
                return new EmployeeResponse($"An error ocurred wile updating the category: {e.Message}");
            }
        }

        public async Task<EmployeeResponse> DeleteAsync(int id)
        {
            var existingCategory = await _employeeRepository.FindByIdAsync(id);

            if (existingCategory == null)
                return new EmployeeResponse("Employee not found");

            try
            {
                _employeeRepository.Remove(existingCategory);

                return new EmployeeResponse(existingCategory);
            }
            catch (Exception e)
            {
                return new EmployeeResponse($"An error occurred while deleting the employee:{e.Message}");
            }
        }
    }
}