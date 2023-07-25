using Company.Helpers;
using Company.Models;
using Company.Services.Interfaces;
using System.Data;

namespace Company.Services.Implements;

public class PositionService : IPositionService
{
    public async Task<int> AddAsync(Position position)
    {
        return await SQLHelper.ExecuteAsync($"INSERT INTO Positions VALUES (N'{position.Name}')");
    }

    public async Task<int> AddAsync(List<Position> positions)
    {
        string query = "INSERT INTO positions VALUES";
        foreach (Position pos in positions)
        {
            query += $"(N'{pos.Name}'),";
        }
        return await SQLHelper.ExecuteAsync(query.Substring(0, query.Length - 1));
    }

    public async Task<int> DeleteAsync(int id)
    {
        await GetByIdAsync(id);
        return await SQLHelper.ExecuteAsync($"DELETE Positions WHERE id = {id}");
    }

    public async Task<List<Position>> GetAllAsync()
    {
        List<Position> positions = new List<Position>();
        DataTable dt = await SQLHelper.SelectAsync("SELECT * FROM Positions");
        foreach (DataRow item in dt.Rows)
        {
            positions.Add(new()
            {
                Id = (int)item["Id"],
                Name = (string)item["Name"]
            });
        }
        return positions;
    }

    public async Task<Position> GetByIdAsync(int id)
    {
        DataTable dt = await SQLHelper.SelectAsync($"SELECT * FROM Positions WHERE Id = {id}");
        if (dt.Rows.Count != 1) throw new Exception("bad request");
        return new Position { Id = id, Name = dt.Rows[0]["Name"].ToString() };
    }

    public async Task<int> UpdateAsync(int id, Position position)
    {
        await GetByIdAsync(id);
        return await SQLHelper.ExecuteAsync($"UPDATE Positions SET Name = '{position.Name}' WHERE id = {id}");
    }
}
