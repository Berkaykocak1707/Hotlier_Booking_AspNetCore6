using Hotlier_Booking_AspNetCore6.Infrastructure.Extensions;
namespace Hotlier_Booking_AspNetCore6
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            builder.Services.AddControllersWithViews();
            builder.Services.AddRazorPages();

            builder.Services.ConfigureDbContext(builder.Configuration); //DbContext
            builder.Services.ConfigureIdentity(); //Identity

            builder.Services.ConfigureRepoRegistration(); //ServiceExtension.cs
            builder.Services.ConfigureServiceRegistration(); //ServiceExtension.cs
            builder.Services.ConfigureRouting(); //ServiceExtension.cs
            builder.Services.ConfigureApplicationCookie();
            builder.Services.ConfigureSession();
            builder.Services.AddAutoMapper(typeof(Program));
            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.ConfigureAndCheckMigration();

            app.ConfigureDefaultAdminUser(); //Identity

            app.UseRouting();

            app.UseAuthentication(); //Identity
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {

                endpoints.MapAreaControllerRoute(
                    name: "Admin",
                    areaName: "Admin",
                    pattern: "Admin/{controller=Dashboard}/{action=Index}/{id?}");

                endpoints.MapControllerRoute("default", "{controller=Home}/{action=Index}/{id?}");

            });

            app.Run();
        }
    }
}