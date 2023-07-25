using Company.Models;
using Company.Services.Interfaces;

namespace Company.Services.Implements
{
    public class EmployeeService : IEmployeeService
    {
        public Task<int> AddAsync(Employee employee)
        {
            throw new NotImplementedException();
        }

        public Task<int> AddAsync(List<Employee> employees)
        {
            throw new NotImplementedException();
        }

        public Task<int> DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<List<Employee>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<Employee> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<int> UpdateAsync(int id, Employee employee)
        {
            throw new NotImplementedException();
        }
    }
}
