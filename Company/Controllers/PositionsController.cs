using Company.Helpers;
using Company.Models;
using Company.Services.Implements;
using Company.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Data;

namespace Company.Controllers
{
    public class PositionsController : Controller
    {
        public async Task<IActionResult> IndexAsync()
        {
            List<Position> positions = new List<Position>();
            DataTable dt = await SQLHelper.SelectAsync("SELECT * FROM Positions");
            foreach (DataRow item in dt.Rows)
            {
                positions.Add(new()
                {
                    Id = (int)item["ID"],
                    Name = (string)item["Name"]
                });
            }
            return View(positions);
        }
        public async Task<IActionResult> GetAllPositions()
        {
            IPositionService service = new PositionService();
            return Json(await service.GetAllAsync());
        }
        public async Task<IActionResult> GetPositionById(int id)
        {
            IPositionService service = new PositionService();
            return Json(await service.GetByIdAsync(id));
        }
        public async Task<IActionResult> AddPosition(List<string> names)
        {
            IPositionService service = new PositionService();
            List<Position> positions = new List<Position>();
            foreach (var item in names)
            {
                positions.Add(new Position()
                {
                    Name = item
                });
            }
            await service.AddAsync(positions);
            return Json(await service.GetAllAsync());
        }

        //hal hazirda delete islemeyecek, cunki sales table da position id ile reference var
        public async Task<IActionResult> DeletePosition(int id)
        {
            IPositionService service = new PositionService();
            if (await service.DeleteAsync(id) > 0) return Ok();
            return NotFound();
        }
        public async Task<IActionResult> UpdatePosition(int id, string name)
        {
            IPositionService service = new PositionService();
            await service.UpdateAsync(id, new Position() { Name = name });
            return Json(await service.GetByIdAsync(id));
        }

    }
}
