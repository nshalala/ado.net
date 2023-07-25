using Company.Helpers;
using Company.Models;
using Company.Services.Interfaces;
using System.Data;

namespace Company.Services.Implements;

public class BranchService : IBranchService
{
    public async Task<int> AddAsync(Branch branch)
    {
        return await SQLHelper.ExecuteAsync($"INSERT INTO Branches VALUES (N'{branch.Name}')");
    }

    public async Task<int> AddAsync(List<Branch> branches)
    {
        string query = "INSERT INTO Branches VALUES";
        foreach (Branch br in branches)
        {
            query += $"(N'{br.Name}'),";
        }
        return await SQLHelper.ExecuteAsync(query.Substring(0, query.Length - 1));
    }

    public async Task<int> DeleteAsync(int id)
    {
        await GetByIdAsync(id);
        return await SQLHelper.ExecuteAsync($"DELETE Branches WHERE id = {id}");
    }

    public async Task<List<Branch>> GetAllAsync()
    {
        List<Branch> branches = new List<Branch>();
        DataTable dt = await SQLHelper.SelectAsync("SELECT * FROM Branches");
        foreach (DataRow item in dt.Rows)
        {
            branches.Add(new() {
                Id = (int)item["Id"],
                Name = (string)item["Name"]
            });
        }
        return branches;
    }

    public async Task<Branch> GetByIdAsync(int id)
    {
        DataTable dt = await SQLHelper.SelectAsync($"SELECT * FROM Branches WHERE Id = {id}");
        if (dt.Rows.Count != 1) throw new Exception("bad request");
        return new Branch { Id = id, Name = dt.Rows[0]["Name"].ToString() };
    }

    public async Task<int> UpdateAsync(int id, Branch branch)
    {
        await GetByIdAsync(id);
        return await SQLHelper.ExecuteAsync($"UPDATE Branches SET Name = '{branch.Name}' WHERE id = {id}");
    }
}
