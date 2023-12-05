using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace storeapp.Areas.Admin.Controllers
{
    [Authorize]
    [Authorize(Policy = "EditorOnly")]
    [Area("Admin")]
    public class DashboardController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
