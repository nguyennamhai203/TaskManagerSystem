using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace App_TaskManagerSystem.Areas.Admin.Controllers
{
    [Area("Admin")]
    //[Authorize("Admin")]
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
