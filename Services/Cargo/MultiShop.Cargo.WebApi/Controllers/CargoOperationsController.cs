using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using MultiShop.Cargo.BusinessLayer.Abstract;
using MultiShop.Cargo.DtoLayer.Dtos.CargoOperationDtos;
using MultiShop.Cargo.EntityLayer.Concrete;

namespace MultiShop.Cargo.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CargoOperationsController : ControllerBase
    {
        private readonly ICargoOperationService _cargoOperationService;
        private readonly IMapper _mapper;

        public CargoOperationsController(IMapper mapper, ICargoOperationService cargoOperationService)
        {
            _mapper = mapper;
            _cargoOperationService = cargoOperationService;
        }

        [HttpGet]
        public IActionResult CargoOperationList()
        {
            var values = _cargoOperationService.TGetAll();

            var result = _mapper.Map<List<ResultCargoOperationDto>>(values);

            return Ok(result);
        }

        [HttpGet("{id}")]
        public IActionResult GetCargoOperationById(int id)
        {
            var value = _cargoOperationService.TGetById(id);

            var result = _mapper.Map<GetByIdCargoOperationDto>(value);

            return Ok(result);
        }

        [HttpPost]
        public IActionResult CreateCargoOperation(CreateCargoOperationDto createCargoOperationDto)
        {
            var value = _mapper.Map<CargoOperation>(createCargoOperationDto);

            _cargoOperationService.TInsert(value);

            return Ok("Cargo operation created successfully.");
        }

        [HttpPut]
        public IActionResult UpdateCargoOperation(UpdateCargoOperationDto updateCargoOperationDto)
        {
            var value = _mapper.Map<CargoOperation>(updateCargoOperationDto);

            _cargoOperationService.TUpdate(value);

            return Ok("Cargo operation updated successfully.");
        }

        [HttpDelete]
        public IActionResult RemoveCargoOperation(int id)
        {
            _cargoOperationService.TDelete(id);

            return Ok("Cargo operation removed successfully.");
        }
    }
}
