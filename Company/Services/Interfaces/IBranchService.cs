using Company.Models;

namespace Company.Services.Interfaces;

public interface IBranchService
{
    public Task<int> AddAsync(Branch branch);
    public Task<int> AddAsync(List<Branch> branches);
    public Task<List<Branch>> GetAllAsync();
    public Task<Branch> GetByIdAsync(int id);
    public Task<int> DeleteAsync(int id);
    public Task<int> UpdateAsync(int id, Branch branch);
}
