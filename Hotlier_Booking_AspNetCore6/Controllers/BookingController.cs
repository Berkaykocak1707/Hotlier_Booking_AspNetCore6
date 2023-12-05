using Entities.Dtos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Repositories.Contracts;

namespace Hotlier_Booking_AspNetCore6.Controllers
{
    public class BookingController : Controller
    {
        private readonly IServiceManager _services;

        public BookingController(IServiceManager services)
        {
            _services = services;
        }

        public IActionResult Index()
        {
            ViewBag.CheckIn = TempData["CheckIn"];
            ViewBag.CheckOut = TempData["CheckOut"];
            ViewBag.SelectedAdult = TempData["SelectedAdult"];
            ViewBag.SelectedChild = TempData["SelectedChild"];

            ViewBag.Rooms = new SelectList(_services.RoomService.GetAllRooms(),"RoomID","RoomName","1");

            var SubsDto = new SubscribeDtoForCreation { };
            ViewData["SubsDto"] = SubsDto;
            return View();
        }
        [HttpPost]
        public IActionResult Index([FromForm]BookingDtoForCreation bookingDtoForCreation)
        {
            if (ModelState.IsValid)
            {
                _services.BookingService.CreateBooking(bookingDtoForCreation);
                TempData["Message"] = "Booking has created. Check your mailbox for details.";
            }
           return RedirectToAction("Index");
        }
    }
}
