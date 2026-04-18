using Microsoft.AspNetCore.Mvc;

namespace EmployeeTaskProgress.Controllers
{
    public class Setting : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
