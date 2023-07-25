using Microsoft.AspNetCore.Mvc;

namespace Company.Controllers
{
    public class EmployeesController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
