using Microsoft.AspNetCore.Mvc;
using MultiShop.DtoLayer.OrderDtos.AddressDtos;
using MultiShop.WebUI.Services.Interfaces;
using MultiShop.WebUI.Services.OrderServices.AddressServices;
using System.Threading.Tasks;

namespace MultiShop.WebUI.Controllers
{
    public class OrderController : Controller
    {
        private readonly IAddressService _addressService;
        private readonly IUserService _userService;

        public OrderController(IAddressService addressService, IUserService userService)
        {
            _addressService = addressService;
            _userService = userService;
        }

        [HttpGet]
        public IActionResult Index()
        {
            ViewBag.directory1 = "Ana Sayfa";
            ViewBag.directory2 = "Siparişler";
            ViewBag.directory3 = "Sipariş İşlemleri";

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Index(CreateAddressDto createAddressDto)
        {
            var value = await _userService.GetUserInfo();
            createAddressDto.UserID = value.Id;

            await _addressService.CreateAsync(createAddressDto);

            return RedirectToAction("Index", "Payment");
        }
    }
}
