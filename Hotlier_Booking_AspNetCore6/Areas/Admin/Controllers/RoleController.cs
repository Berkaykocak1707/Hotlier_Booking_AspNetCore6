using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Repositories.Contracts;

namespace storeapp.Areas.Admin.Controllers
{
    [Authorize]
    [Authorize(Policy = "AdminOnly")]
    [Area("Admin")]
    public class RoleController : Controller
    {
        private readonly IServiceManager _serviceManager;
        public RoleController(IServiceManager serviceManager)
        {
            _serviceManager = serviceManager;
        }

        public IActionResult Role()
        {
            return View(_serviceManager.AuthService.GetRoles);
        }
        public IActionResult CreateRole()
        {
            return View();
        }
    }
}
