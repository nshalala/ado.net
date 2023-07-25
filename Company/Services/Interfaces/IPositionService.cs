using Company.Models;

namespace Company.Services.Interfaces;

public interface IPositionService
{
    public Task<int> AddAsync(Position position);
    public Task<int> AddAsync(List<Position> positions);
    public Task<List<Position>> GetAllAsync();
    public Task<Position> GetByIdAsync(int id);
    public Task<int> DeleteAsync(int id);
    public Task<int> UpdateAsync(int id, Position position);
}
