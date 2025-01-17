using App_TaskManagerSystem.HelpersApp;
using App_TaskManagerSystem.Models;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Diagnostics;
using System.Security.Claims;
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
        public async Task<IActionResult> LoginWithJWT(LoginDto loginDto)
        {
            try
            {
                var apiUrl = $"/api/Account";
                var httpclient = _httpClientFactory.CreateClient("BeHat");
                var requestData = new StringContent(JsonConvert.SerializeObject(loginDto), Encoding.UTF8, "application/json");
                var response = await httpclient.PostAsync(apiUrl, requestData);
                response.EnsureSuccessStatusCode();

                var jsonResponse = await response.Content.ReadAsStringAsync();
                //var loginResult = JsonSerializer.Deserialize<LoginResult>(jsonResponse); // Use System.Text.Json for deserialization

                if (jsonResponse == null || string.IsNullOrEmpty(jsonResponse))
                {
                    return BadRequest("Invalid login response.");
                }

                // Create claims for the user
                var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name,jsonResponse ), // Example: Add username to claims
                new Claim("Role", jsonResponse)
            };

                // Create a new ClaimsIdentity
                var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);

                // Create a new ClaimsPrincipal
                var principal = new ClaimsPrincipal(claimsIdentity);

                // Sign in the user
                await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal);

                // Redirect to the appropriate area based on role
                return RedirectToAction("Index", "Home", new { area = jsonResponse });

            }
            catch (Exception ex)
            {
                // Log the exception for debugging
                // ...

                return BadRequest("Login failed.");
            }
        }

        // ... other actions
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

        public class LoginResult
    {
        public string Token { get; set; }
        public string Role { get; set; }
    }
    
    }
}