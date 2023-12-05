using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Repositories.Contracts;
using System.Xml.Linq;

namespace Hotlier_Booking_AspNetCore6.Areas.Admin.Controllers
{
    [Authorize]
    [Authorize(Policy = "EditorOnly")]
    [Area("Admin")]
    public class SubscribeController : Controller
    {
        private readonly IServiceManager _serviceManager;
        public SubscribeController(IServiceManager serviceManager)
        {
            _serviceManager = serviceManager;
        }
        public IActionResult Index()
        {
            var model = _serviceManager.SubscribeService.GetAllSubscriptions();
            return View(model);
        }

        public IActionResult Delete(int id)
        {
            _serviceManager.SubscribeService.DeleteSubscription(id);
            return RedirectToAction("Index");
        }
    }
}
