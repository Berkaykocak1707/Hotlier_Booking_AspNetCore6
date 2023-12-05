using Business.Contracts;
using Business;
using DataAccess;
using DataAccess.Contracts;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Repositories.Contracts;
using Services;
using Microsoft.AspNetCore.Authentication.Cookies;

namespace Hotlier_Booking_AspNetCore6.Infrastructure.Extensions
{
    public static class ServiceExtension
    {
        public static void ConfigureDbContext(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<RepositoryContext>(options => {
                options.UseSqlServer(configuration.GetConnectionString("sqlconnection"), b => b.MigrationsAssembly("Hotlier_Booking_AspNetCore6"));

                options.EnableSensitiveDataLogging(true);
            });
        }
        public static void ConfigureRepoRegistration(this IServiceCollection services)
        {
            services.AddScoped<IRepositoryManager, RepositoryManager>();
            services.AddScoped<IBookingRepository, BookingRepository>();
            services.AddScoped<IContactRepository, ContactRepository>();
            services.AddScoped<IRoomRepository, RoomRepository>();
            services.AddScoped<ISubscribeRepository, SubscribeRepository>();
        }
        public static void ConfigureServiceRegistration(this IServiceCollection services)
        {
            services.AddScoped<IServiceManager, ServiceManager>();
            services.AddScoped<IRoomService, RoomManager>();
            services.AddScoped<IAuthService, AuthManager>();
            services.AddScoped<IBookingService, BookingManager>();
            services.AddScoped<IContactService, ContactManager>();
            services.AddScoped<ISubscribeService, SubscribeManager>();
        }

        public static void ConfigureIdentity(this IServiceCollection services)
        {
            services.AddIdentity<IdentityUser, IdentityRole>(options =>
            {
                options.SignIn.RequireConfirmedEmail = false;
                options.User.RequireUniqueEmail = true;
                options.Password.RequireUppercase = false;
                options.Password.RequireLowercase = false;
                options.Password.RequireDigit = false;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequiredLength = 5;
            })
                .AddEntityFrameworkStores<RepositoryContext>();
            services.AddAuthorization(options =>
            {
                options.AddPolicy("AdminOnly", policy => policy.RequireRole("Admin"));
                options.AddPolicy("EditorOnly", policy => policy.RequireRole("Editor"));
            });

        }
        public static void ConfigureSession(this IServiceCollection services)
        {
            services.AddDistributedMemoryCache();
            services.AddSession(options =>
            {
                options.Cookie.Name = "StoreApp.Session";
                options.IdleTimeout = TimeSpan.FromMinutes(10);
            });
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
        }
        public static void ConfigureApplicationCookie(this IServiceCollection services)
        {
            services.ConfigureApplicationCookie(options =>
            {
                options.LoginPath = new PathString("/admin/account/login/");
                options.ReturnUrlParameter = CookieAuthenticationDefaults.ReturnUrlParameter;
                options.ExpireTimeSpan = TimeSpan.FromMinutes(30);
                options.AccessDeniedPath = new PathString("/admin/account/AccessDenied/");
            });
        }
        public static void ConfigureRouting(this IServiceCollection services)
        {
            services.AddRouting(options =>
            {
                options.LowercaseUrls = true;
                options.AppendTrailingSlash = true;
            });
        }
    }
}
