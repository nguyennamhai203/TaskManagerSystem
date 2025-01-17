using Microsoft.AspNetCore.Mvc;

namespace App_TaskManagerSystem.Areas.User.Controllers
{   
    [Area("User")]
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult About()
        {
            return View();
        }
    }
}
