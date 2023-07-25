using Company.Models;

namespace Company.Services.Interfaces
{
    public interface IEmployeeService
    {
        public Task<int> AddAsync(Employee employee);
        public Task<int> AddAsync(List<Employee> employees);
        public Task<List<Employee>> GetAllAsync();
        public Task<Employee> GetByIdAsync(int id);
        public Task<int> DeleteAsync(int id);
        public Task<int> UpdateAsync(int id, Employee employee);
    }
}
