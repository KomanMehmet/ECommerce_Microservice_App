﻿using Microsoft.AspNetCore.Mvc;
using MultiShop.DtoLayer.CargoDtos.CargoCompanyDtos;
using MultiShop.WebUI.Services.CargoServices.CargoCompanyServices;

namespace MultiShop.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("Admin/Cargo")]
    public class CargoController : Controller
    {
        private readonly ICargoCompanyService _cargoCompanyService;

        public CargoController(ICargoCompanyService cargoCompanyService)
        {
            _cargoCompanyService = cargoCompanyService;
        }

        [HttpGet]
        [Route("CargoCompanyList")]
        public async Task<IActionResult> CargoCompanyList()
        {
            var cargoCompanies = await _cargoCompanyService.GetAllCargoCompaniesAsync();

            return View(cargoCompanies);
        }

        [HttpGet]
        [Route("CreateCargoCompany")]
        public async Task<IActionResult> CreateCargoCompany()
        {
            return View();
        }

        [HttpPost]
        [Route("CreateCargoCompany")]
        public async Task<IActionResult> CreateCargoCompany(CreateCargoCompanyDto createCargoCompanyDto)
        {
            await _cargoCompanyService.CreateCargoCompanyAsync(createCargoCompanyDto);

            return RedirectToAction("CargoCompanyList", "Cargo", new { area = "Admin" });
        }

        [HttpGet]
        [Route("UpdateCargoCompany/{id}")]
        public async Task<IActionResult> UpdateCargoCompany(int id)
        {
            var cargoCompany = await _cargoCompanyService.GetCargoCompanyByIdAsync(id);

            return View(cargoCompany);
        }

        [HttpPost]
        [Route("UpdateCargoCompany/{id}")]
        public async Task<IActionResult> UpdateCargoCompany(UpdateCargoCompanyDto updateCargoCompanyDto)
        {
            await _cargoCompanyService.UpdateCargoCompanyAsync(updateCargoCompanyDto);

            return RedirectToAction("CargoCompanyList", "Cargo", new { area = "Admin" });
        }

        [Route("DeleteCargoCompany/{id}")]
        public async Task<IActionResult> DeleteCargoCompany(int id)
        {
            await _cargoCompanyService.DeleteCargoCompanyAsync(id);

            return RedirectToAction("CargoCompanyList", "Cargo", new { area = "Admin" });
        }
    }
}
