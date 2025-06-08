using Microsoft.AspNetCore.Mvc;
using MultiShop.WebUI.Services.CargoServices.CargoCustomerServices;
using MultiShop.WebUI.Services.UserIdentityServices;

namespace MultiShop.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("Admin/User")]
    public class UserController : Controller
    {
        private readonly IUserIdentityService _userIdentityService;
        private readonly ICargoCustomerService _cargoCustomerService;

        public UserController(IUserIdentityService userIdentityService, ICargoCustomerService cargoCustomerService)
        {
            _userIdentityService = userIdentityService;
            _cargoCustomerService = cargoCustomerService;
        }

        [HttpGet]
        [Route("UserList")]
        public async Task<IActionResult> UserList()
        {
            var values = await _userIdentityService.GetUserListAsync();

            return View(values);
        }

        public async Task<IActionResult> DeleteUser()
        {
            return View();
        }

        [HttpGet]
        [Route("UserAddressInfo/{id}")]
        public async Task<IActionResult> UserAddressInfo(string id)
        {
            var cargoCustomer = await _cargoCustomerService.GetCargoCustomerByUserIdAsync(id);

            return View(cargoCustomer);
        }
    }
}
