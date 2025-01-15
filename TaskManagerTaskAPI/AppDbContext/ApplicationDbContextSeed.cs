using Microsoft.AspNetCore.Identity;
using TaskManagerModels.Models;

namespace TaskManagerTaskAPI.AppDbContext
{
    public class ApplicationDbContextSeed
    {
        public static async Task SeedDefaultUser(UserManager<Users> userManager, RoleManager<Roles> roleManager)
        {
            var defaultUser = await userManager.FindByEmailAsync("defaultuser@example.com");

            if (defaultUser == null)
            {
                // Tạo người dùng mới
                var user = new Users
                {
                    UserName = "defaultuser@example.com",
                    Email = "defaultuser@example.com",
                    AccountName = "taikhoan1",
                    FirstName = "John",
                    LastName = "Doe",
                    PhoneNumber = "1234567890",
                    Sex = 1, // Giới tính nam (hoặc theo giá trị mà bạn định nghĩa)
                    Status = 1, // Trạng thái hoạt động
                    VerificationCode = "some-code",
                    VerificationCodeExpiry = DateTime.Now.AddHours(1)
                };

                var result = await userManager.CreateAsync(user, "@Chamhet03"); // Mật khẩu mặc định

                if (result.Succeeded)
                {
                    // Thêm user vào vai trò (nếu cần)
                    if (await roleManager.FindByNameAsync("Admin") == null)
                    {
                        var role = new  Roles {
                            Id= Guid.NewGuid(),
                            RoleCode = "Admin01",
                            RoleName = "Admin",
                            Name= "Admin",
                            Status = 1
                        };
                        var a = await roleManager.CreateAsync(role);
                    }
                    await userManager.AddToRoleAsync(user, "Admin");
                }
            }
        }
    }
}
