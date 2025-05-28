using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MultiShop.Catalog.Dtos.ContactDtos;
using MultiShop.Catalog.Services.ContactServices;

namespace MultiShop.Catalog.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [AllowAnonymous]
    public class ContactsController : ControllerBase
    {
        private readonly IContactService _contactService;

        public ContactsController(IContactService contactService)
        {
            _contactService = contactService;
        }

        [HttpGet]
        public async Task<IActionResult> GetContacts()
        {
            var result = await _contactService.GetAllContactAsync();

            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetContactById(string id)
        {
            var result = await _contactService.GetByIdContactAsync(id);

            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> CreateContact(CreateContactDto createContactDto)
        {
            await _contactService.CreateContactyAsync(createContactDto);

            return Ok("Contact created successfully.");
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteContact(string id)
        {
            await _contactService.DeleteContactAsync(id);

            return Ok("Contact deleted successfully.");
        }

        [HttpPut]
        public async Task<IActionResult> UpdateContact(UpdateContactDto updateContactDto)
        {
            await _contactService.UpdateContactyAsync(updateContactDto);

            return Ok("Contact updated successfully.");
        }
    }
}
