using Company.Helpers;
using Company.Models;
using Company.Services.Implements;
using Company.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Data;
using System.Data.SqlClient;

namespace Company.Controllers
{
    public class HomeController : Controller
    {
        public async Task<IActionResult> Index()
        {
            List<Branch> branches = new List<Branch>();
            DataTable dt = await SQLHelper.SelectAsync("SELECT * FROM Branches");
            foreach (DataRow item in dt.Rows)
            {
                branches.Add(new()
                {
                    Id = (int)item["ID"],
                    Name = (string)item["Name"]
                });
            }
            return View(branches);
        }
        public async Task<IActionResult> GetAllBranches()
        {
            IBranchService service = new BranchService();
            return Json(await service.GetAllAsync());
        }
        public async Task<IActionResult> GetBranchById(int id)
        {
            IBranchService service = new BranchService();
            return Json(await service.GetByIdAsync(id));
        }
        public async Task<IActionResult> AddBranch(string name)
        {
            IBranchService service = new BranchService();
            await service.AddAsync(new Branch() { Name = name });
            return Json(await service.GetAllAsync());
        }
        public async Task<IActionResult> AddBranch(List<string> names)
        {
            IBranchService service = new BranchService();
            List<Branch> branches = new List<Branch>();
            foreach (var item in names)
            {
                branches.Add(new Branch()
                {
                    Name = item
                });
            }
            await service.AddAsync(branches);
            return Json(await service.GetAllAsync());
        }
        
        //hal hazirda delete islemeyecek, cunki sales table da branch id ile reference var
        public async Task<IActionResult> DeleteBranch(int id)
        {
            IBranchService service = new BranchService();
            if (await service.DeleteAsync(id) > 0) return Ok();
            return NotFound();
        } 
        public async Task<IActionResult> UpdateBranch(int id, string name)
        {
            IBranchService service = new BranchService();
            await service.UpdateAsync(id, new Branch() { Name = name });
            return Json(await service.GetByIdAsync(id));
        }
    }
}
