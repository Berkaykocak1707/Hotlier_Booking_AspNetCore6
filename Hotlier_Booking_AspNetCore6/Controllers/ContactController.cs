using Entities.Dtos;
using Microsoft.AspNetCore.Mvc;
using Repositories.Contracts;

namespace Hotlier_Booking_AspNetCore6.Controllers
{
    public class ContactController : Controller
    {
        private readonly IServiceManager _serviceManager;
        public ContactController(IServiceManager serviceManager)
        {
            _serviceManager = serviceManager;
        }

        public IActionResult Index()
        {
            var SubsDto = new SubscribeDtoForCreation { };
            ViewData["SubsDto"] = SubsDto;
            return View();
        }
        [HttpPost]
        public IActionResult Index([FromForm]ContactDtoForCreation contactDtoForCreation)
        {
            if (contactDtoForCreation.ContactMessage == null)
            {
                TempData["Message"] = "Message is empty";
                return View();
            }
            else if (ModelState.IsValid)
            {
                _serviceManager.ContactService.CreateContact(contactDtoForCreation);
                TempData["Message"] = "Contact has created.";
                return View();
            }
            TempData["Message"] = "Form is empty or invalid";
            return View();
        }
        [HttpPost]
        public IActionResult Subscribe([FromForm]SubscribeDtoForCreation subscribeDtoForCreation)
        {
            if (ModelState.IsValid)
            {
                _serviceManager.SubscribeService.CreateSubscription(subscribeDtoForCreation);
                TempData["Message"] = "Subscribed! Check your mailbox for notifications!";
                return RedirectToAction("Index");
            }
            return RedirectToAction("Index");
        }
    }
}
