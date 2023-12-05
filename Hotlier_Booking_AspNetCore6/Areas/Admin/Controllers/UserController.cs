using Entities.Dtos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Repositories.Contracts;

namespace Hotlier_Booking_AspNetCore6.Areas.Admin.Controllers
{
    [Authorize]
    [Authorize(Policy = "AdminOnly")]
    [Area("Admin")]
    public class UserController : Controller
    {
        private readonly IServiceManager _serviceManager;
        public UserController(IServiceManager serviceManager)
        {
            _serviceManager = serviceManager;
        }
        public IActionResult Users()
        {
            var users = _serviceManager.AuthService.GetUsers();
            return View(users);
        }
        public IActionResult Create()
        {
            return View(new UserDtoForCreation()
            {
                Roles = new HashSet<string>(_serviceManager.AuthService.GetRoles.Select(R => R.Name).ToList())
            });
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([FromForm] UserDtoForCreation userDto)
        {
            var result = await _serviceManager.AuthService.CreateUser(userDto);
            return result.Succeeded
            ? RedirectToAction("Users")
            : View();
        }
        public async Task<IActionResult> Update([FromRoute(Name = "id")] string id)
        {
            var user = await _serviceManager.AuthService.GetOneUserForUpdate(id);
            return View(user);

        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Update([FromForm] UserDtoForUpdate userDtoFor)
        {
            if (ModelState.IsValid)
            {
                await _serviceManager.AuthService.Update(userDtoFor);
                return RedirectToAction("Users");
            }
            return View();

        }
        public IActionResult ResetPassword([FromRoute(Name = "id")] string id)
        {

            return View(new ResetPasswordDto()
            {
                Username = id
            });

        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ResetPassword([FromForm] ResetPasswordDto userDtoFor)
        {
            if (ModelState.IsValid)
            {
                await _serviceManager.AuthService.ResetPassword(userDtoFor);
                return RedirectToAction("Users");
            }
            return View();

        }
        public async Task<IActionResult> DeleteUser([FromRoute] String id)
        {
            if (id is not null)
            {
                await _serviceManager.AuthService.DeleteOneUser(id);
                return RedirectToAction("Users");
            }

            return RedirectToAction("Users");

        }
    }
}
