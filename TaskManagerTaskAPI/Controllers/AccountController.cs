using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using TaskManagerModels.Models;
using TaskManagerTaskAPI.AppDbContext;

namespace TaskManagerTaskAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly UserManager<Users> _userManager;
        private readonly SignInManager<Users> _signInManager;
        private readonly IConfiguration _configuration;
        private readonly RoleManager<Roles> _roleManager;
        private readonly ApplicationDbContext _context;

        public AccountController(IConfiguration configuration,UserManager<Users> userManager,SignInManager<Users> signInManager, RoleManager<Roles> roleManager, ApplicationDbContext context)
        {
            _signInManager = signInManager;
            _roleManager = roleManager;
            _context = context;
            _userManager = userManager;
            _configuration = configuration;
        }

        public class LoginDto {
            public string? NameAccount { get; set; }
            public string? Password { get; set; }
        };
        [HttpPost]
        public async Task<string> LoginAsync(LoginDto model)
        {
            if (model.NameAccount == null || model.Password == null)
            {
                return "Vui Lòng Nhập Thông Tin !";
            }

            var user = await _userManager.FindByNameAsync(model.NameAccount);

            var passWordVaild = await _userManager.CheckPasswordAsync(user, model.Password);

            if (user == null || !passWordVaild)
            {
                return "Thông tin tài khoản không chính xác !";
                //    new LoginResponseDto
                //{
                //    Message = "Thông tin tài khoản không chính xác !",
                //    Success = false,
                //    Code = 405,
                //};
            }
            var authClamis = new List<Claim>
            {
                new Claim(ClaimTypes.Name,model.NameAccount),
                new Claim(JwtRegisteredClaimNames.Jti,Guid.NewGuid().ToString()),
            };

            var userRoles = await _userManager.GetRolesAsync(user);
            string roleUser = "";
            foreach (var role in userRoles)
            {
                authClamis.Add(new Claim(ClaimTypes.Role, role.ToString()));
                roleUser = role;
            }

            var authenKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JWT:Secret"]));

            JwtSecurityToken token = new(
                issuer: _configuration["JWT:ValidIssuer"],
                audience: _configuration["JWT:ValidAudience"],
                expires: DateTime.Now.AddMinutes(20),
                claims: authClamis,
                signingCredentials: new SigningCredentials(authenKey, SecurityAlgorithms.HmacSha256)
                );

            //return new JwtSecurityTokenHandler().WriteToken(token);

            //return new LoginResponseDto
            //{
            //    Token = new JwtSecurityTokenHandler().WriteToken(token),
            //    Result = user,
            //    Role = roleUser,
            //    Success = true,
            //    Code = 200,
            //};

            return $"{roleUser}";
        }
    }
}
