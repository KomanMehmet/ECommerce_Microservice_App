using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MultiShop.Catalog.Dtos.AboutDtos;
using MultiShop.Catalog.Services.AboutServices;

namespace MultiShop.Catalog.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class AboutsController : ControllerBase
    {
        private readonly IAboutservice _aboutservice;

        public AboutsController(IAboutservice aboutservice)
        {
            _aboutservice = aboutservice;
        }

        [HttpGet]
        public async Task<IActionResult> AboutList()
        {
            var values = await _aboutservice.GetAllAboutAsync();

            return Ok(values);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetAboutById(string id)
        {
            var value = await _aboutservice.GetByIdAboutAsync(id);

            return Ok(value);
        }

        [HttpPost]
        public async Task<IActionResult> CreateAbout(CreateAboutDto createAboutDto)
        {
            await _aboutservice.CreateAboutAsync(createAboutDto);

            return Ok("About created successfully. ");
        }

        [HttpPut]
        public async Task<IActionResult> UpdateAbout(UpdateAboutDto updateAboutDto)
        {
            await _aboutservice.UpdateAboutAsync(updateAboutDto);

            return Ok("About updated successfully.");
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteAbout(string id)
        {
            await _aboutservice.DeleteAboutAsync(id);

            return Ok("About deleted successfully.");
        }
    }
}
