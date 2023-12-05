using Business.Contracts;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Repositories.Contracts;

namespace Hotlier_Booking_AspNetCore6.Areas.Admin.Controllers
{
    [Authorize]
    [Authorize(Policy = "EditorOnly")]
    [Area("Admin")]
    public class BookingController : Controller
    {
        private readonly IServiceManager _serviceManager;
        public BookingController(IServiceManager serviceManager)
        {
            _serviceManager = serviceManager;
        }
        public IActionResult Index()
        {
            var model = _serviceManager.BookingService.GetBookingWithRoomName(false);
            return View(model);
        }

        [HttpGet]
        public IActionResult Delete([FromRoute(Name = "id")] int id)
        {
            _serviceManager.BookingService.DeleteBooking(id);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Done([FromRoute(Name = "id")] int id)
        {
            _serviceManager.BookingService.Done(id);
            return RedirectToAction("Index");
        }
    }
}
