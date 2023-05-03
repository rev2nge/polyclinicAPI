using Microsoft.AspNetCore.Mvc;
using polyclinic.Models;
using AutoMapper;
using polyclinic.Dto;
using polyclinic.Interface;
using Microsoft.AspNetCore.Authorization;

namespace polyclinic.Controllers
{
    [Route("api/[controller]")]
    [AllowAnonymous]
    [ApiController]
    public class CityController : ControllerBase
    {
        private readonly IUnitOfWork _uow;
        private readonly IMapper _mapper;

        public CityController(IUnitOfWork uow, IMapper mapper)
        {
            _uow = uow;
            _mapper = mapper;
        }

        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> GetCities()
        {
            var cities = await _uow.CityRepository.GetCitiesAsync();
            var citiesDto = _mapper.Map<IEnumerable<CityDto>>(cities);
            return Ok(citiesDto);
        }

        [HttpPost("CreateCity")]
        [AllowAnonymous]
        public async Task<IActionResult> CreateCity(CityDto cityDto)
        {
            var city = _mapper.Map<City>(cityDto);
            _uow.CityRepository.CreateCity(city);
            await _uow.SaveAsync();
            return StatusCode(201);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateCity(int id, CityDto cityDto)
        {
            if (id != cityDto.Id)
                return BadRequest("Update not allowed");

            var cityFromDb = await _uow.CityRepository.GetCityById(id);

            if (cityFromDb == null)
                return BadRequest("Update not allowed");

            _mapper.Map(cityDto, cityFromDb);

            await _uow.SaveAsync();
            return StatusCode(200);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateCity(int id, CityUpdateDto cityDto)
        {
            var cityFromDb = await _uow.CityRepository.GetCityById(id);
            _mapper.Map(cityDto, cityFromDb);
            await _uow.SaveAsync();
            return StatusCode(200);
        }

        //[HttpPatch("update/{id}")]
        //public async Task<IActionResult> UpdateCityPatch(int id, JsonPatchDocument<City> cityToPatch)
        //{
        //    var cityFromDb = await _uow.CityRepository.GetCityById(id);

        //    cityToPatch.ApplyTo(cityFromDb, ModelState);
        //    await _uow.SaveAsync();
        //    return StatusCode(200);
        //}

        [HttpDelete]
        public async Task<IActionResult> DeleteCity(int id)
        {
            _uow.CityRepository.DeleteCity(id);
            await _uow.SaveAsync();
            return Ok(id);
        }
    }
}