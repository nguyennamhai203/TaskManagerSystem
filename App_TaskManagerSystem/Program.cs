using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using App_TaskManagerSystem.Data;
using App_TaskManagerSystem.HelpersApp;
using Microsoft.AspNetCore.Authorization;

namespace App_TaskManagerSystem
{
    public class Program
    {
        public static void Main(string[] args)
        {

            var builder = WebApplication.CreateBuilder(args);
                        var connectionString = builder.Configuration.GetConnectionString("App_TaskManagerSystemContextConnection") ?? throw new InvalidOperationException("Connection string 'App_TaskManagerSystemContextConnection' not found.");

                                    builder.Services.AddDbContext<App_TaskManagerSystemContext>(options =>
                options.UseSqlServer(connectionString));

                                                builder.Services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
                .AddEntityFrameworkStores<App_TaskManagerSystemContext>();

            builder.Services.AddHttpClient("BeHat", hat =>
            {
                hat.BaseAddress = new Uri(builder.Configuration["UrlApiAdmin"]);

            });

            // Startup.cs
            //builder.Services.AddAuthorization(options =>
            //{
            //    options.AddPolicy("AdminOnly", policy =>
            //    {
            //        policy.Requirements.Add(new AuthorizationRequirement("Admin"));
            //    });

            //    options.AddPolicy("NhanVienOnly", policy =>
            //    {
            //        policy.Requirements.Add(new AuthorizationRequirement("NhanVien"));
            //    });
            //});

            //services.AddSingleton<IAuthorizationHandler, RoleAuthorizationHandler>();


            // Add services to the container.
            builder.Services.AddControllersWithViews();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();
                        app.UseAuthentication();;

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "area",
                    pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}");  
                
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");

            });

            app.MapRazorPages();
         

            app.Run();
        }
    }
}