using Entities.Dtos;
using Microsoft.AspNetCore.Mvc;
using Repositories.Contracts;

namespace Hotlier_Booking_AspNetCore6.Controllers
{
    public class RoomController : Controller
    {
        private readonly IServiceManager _services;

        public RoomController(IServiceManager services)
        {
            _services = services;
        }

        public IActionResult Index()
        {
            var SubsDto = new SubscribeDtoForCreation { };
            ViewData["SubsDto"] = SubsDto;
            var model = _services.RoomService.GetAllRooms();
            return View(model);
        }
    }
}
