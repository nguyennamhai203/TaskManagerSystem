//using Microsoft.AspNetCore.Authorization;

//namespace App_TaskManagerSystem.HelpersApp
//{
//    // Custom attribute
//    public class CustomAuthorizationHandler : AuthorizationHandler
//    {
//        protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, AuthorizationHandlerRequirement requirement)
//        {
//            // Lấy vai trò từ claim hoặc nguồn dữ liệu khác
//            var user = context.User;
//            var roleClaim = user.FindFirstValue("role");

//            if (roleClaim == "Admin" || roleClaim == "Manager")
//            {
//                context.Succeed(requirement);
//            }

//            return Task.CompletedTask;
//        }
//    }
//}
