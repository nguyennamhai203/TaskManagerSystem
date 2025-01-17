using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace App_TaskManagerSystem.Areas.User.Controllers
{   
    [Area("User")]
    [Authorize(Policy = "UserAreaAccess")]
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
