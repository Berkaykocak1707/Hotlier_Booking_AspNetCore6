using AutoMapper;
using Entities.Dtos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Repositories.Contracts;

namespace Hotlier_Booking_AspNetCore6.Areas.Admin.Controllers
{
    [Authorize]
    [Authorize(Policy = "EditorOnly")]
    [Area("Admin")]
    public class RoomController : Controller
    {
        private readonly IServiceManager _serviceManager;
        private readonly IMapper _mapper;
        public RoomController(IServiceManager serviceManager, IMapper mapper)
        {
            _serviceManager = serviceManager;
            _mapper = mapper;
        }
        public IActionResult Index()
        {
            var rooms = _serviceManager.RoomService.GetAllRooms();
            return View(rooms);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([FromForm] RoomDtoForCreation roomDtoForCreation, IFormFile file)
        {
            if (ModelState.IsValid)
            {
                string originalFileName = file.FileName;
                string fileExtension = Path.GetExtension(originalFileName);
                string roomNameWithoutSpaces = roomDtoForCreation.RoomName.Replace(" ", "");
                string newFileName = roomNameWithoutSpaces + fileExtension;
                string path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "images", newFileName);

                using (var stream = new FileStream(path, FileMode.Create))
                {
                    file.CopyTo(stream);
                }

                // Yeni dosya URL'sini oluşturun
                roomDtoForCreation.RoomPhotoUrl = String.Concat("/images/", newFileName);
                _serviceManager.RoomService.CreateRoom(roomDtoForCreation);
                return RedirectToAction("Index");
            }
            return View();
        }

        public IActionResult Update(int id)
        {
            var model = _serviceManager.RoomService.GetOneRoomForUpdate(id);
            if (model != null)
            {
                return View(model);
            }
            return NotFound();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Update([FromForm] RoomDtoForUpdate roomDtoForUpdate)
        {
            if (ModelState.IsValid)
            {
                _serviceManager.RoomService.UpdateRoom(roomDtoForUpdate);
                return RedirectToAction("Index");
            }
            return View();
        }

        public IActionResult UpdatePhoto(int id)
        {
            var model = _serviceManager.RoomService.GetOneRoomForUpdate(id);
            if (model != null)
            {
                return View(model);
            }
            return NotFound();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult UpdatePhoto([FromForm] RoomDtoForUpdate roomDtoForUpdate, IFormFile file)
        {
            if (ModelState.IsValid)
            {
                string originalFileName = file.FileName;
                string fileExtension = Path.GetExtension(originalFileName);
                string roomNameWithoutSpaces = roomDtoForUpdate.RoomName.Replace(" ", "");
                string newFileName = roomNameWithoutSpaces + fileExtension;
                string path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "images", newFileName);

                using (var stream = new FileStream(path, FileMode.Create))
                {
                    file.CopyTo(stream);
                }

                // Yeni dosya URL'sini oluşturun
                roomDtoForUpdate.RoomPhotoUrl = String.Concat("/images/", newFileName);
                _serviceManager.RoomService.UpdateRoom(roomDtoForUpdate);
                return RedirectToAction("Index");
            }
            return NotFound();
        }

        public IActionResult Delete(int id)
        {
            _serviceManager.RoomService.DeleteRoom(id);
            return RedirectToAction("Index");
        }
    }
}
