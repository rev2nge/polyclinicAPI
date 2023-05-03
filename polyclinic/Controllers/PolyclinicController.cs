using Microsoft.AspNetCore.Mvc;
using polyclinic.Models;
using AutoMapper;
using polyclinic.Dto;
using polyclinic.Interface;
using Microsoft.AspNetCore.Authorization;

namespace polyclinic.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PolyclinicController : ControllerBase
    {
        private readonly IUnitOfWork _uow;
        private readonly IMapper _mapper;

        public PolyclinicController(IUnitOfWork uow, IMapper mapper)
        {
            _uow = uow;
            _mapper = mapper;
        }

        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> GetPolyclinics()
        {
            var polyclinics = await _uow.PolyclinicRepository.GetPolyclinicsAsync();
            var polyclinicsDto = _mapper.Map<IEnumerable<PolyclinicDto>>(polyclinics);
            return Ok(polyclinicsDto);
        }

        [HttpPost]
        public async Task<IActionResult> CreatePolyclinic(PolyclinicDto polyclinicDto)
        {
            var polyclinic = _mapper.Map<Polyclinic>(polyclinicDto);
            _uow.PolyclinicRepository.CreatePolyclinic(polyclinic);
            await _uow.SaveAsync();
            return StatusCode(201);
        }

        [HttpPut]
        public async Task<IActionResult> UpdatePolyclinic(int id, PolyclinicDto polyclinicDto)
        {
            if (id != polyclinicDto.Id)
                return BadRequest("Update not allowed");

            var polyclinicFromDb = await _uow.PolyclinicRepository.GetPolyclinicById(id);

            if (polyclinicFromDb == null)
                return BadRequest("Update not allowed");

            _mapper.Map(polyclinicDto, polyclinicFromDb);

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
        public async Task<IActionResult> DeletePolyclinic(int id)
        {
            _uow.PolyclinicRepository.DeletePolyclinic(id);
            await _uow.SaveAsync();
            return Ok(id);
        }
    }
}