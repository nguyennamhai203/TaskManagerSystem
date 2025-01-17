using App_TaskManagerSystem.HelpersApp;
using App_TaskManagerSystem.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Diagnostics;
using System.Text;

namespace App_TaskManagerSystem.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IHttpClientFactory _httpClientFactory;
        public HomeController(ILogger<HomeController> logger,IHttpClientFactory httpClientFactory)
        {
            _logger = logger;
            _httpClientFactory = httpClientFactory;
        }
        [HttpPost]
        public async Task<IActionResult> LoginWithJWT(LoginDto loginDto/*string username, string password*/)
        {
            //LoginDto login = new LoginDto();
            //login.NameAccount = username;
            //login.Password = password;

            var apiUrl = $"/api/Account";
            var httpclient = _httpClientFactory.CreateClient("BeHat");
            var requestdata = new StringContent(JsonConvert.SerializeObject(loginDto), Encoding.UTF8, "application/json");
            var respone = await httpclient.PostAsync(apiUrl, requestdata);
            var jsonRespone = await respone.Content.ReadAsStringAsync();
            //var info = JsonConvert.DeserializeObject<string>(jsonRespone);

            ViewBag.role = "jsonRespone";



                //return RedirectToAction("Privacy", "Home");

            return RedirectToAction("Privacy", "Home", new { area = jsonRespone });

        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}