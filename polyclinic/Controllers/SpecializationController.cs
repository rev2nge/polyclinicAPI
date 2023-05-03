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
    public class SpecializationController : ControllerBase
    {
        private readonly IUnitOfWork _uow;
        private readonly IMapper _mapper;

        public SpecializationController(IUnitOfWork uow, IMapper mapper)
        {
            _uow = uow;
            _mapper = mapper;
        }

        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> GetSpecializations()
        {
            var specializations = await _uow.SpecializationRepository.GetSpecializationsAsync();
            var specializationDto = _mapper.Map<IEnumerable<SpecializationDto>>(specializations);
            return Ok(specializationDto);
        }

        [HttpPost]
        public async Task<IActionResult> CreateSpecialization(SpecializationDto specializationDto)
        {
            var specialization = _mapper.Map<Specialization>(specializationDto);
            _uow.SpecializationRepository.CreateSpecialization(specialization);
            await _uow.SaveAsync();
            return StatusCode(201);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateSpecialization(int id, SpecializationDto specializationDto)
        {
            if (id != specializationDto.Id)
                return BadRequest("Update not allowed");

            var specializationFromDb = await _uow.SpecializationRepository.GetSpecializationById(id);

            if (specializationFromDb == null)
                return BadRequest("Update not allowed");

            _mapper.Map(specializationDto, specializationFromDb);

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
        public async Task<IActionResult> DeleteSpecialization(int id)
        {
            _uow.SpecializationRepository.DeleteSpecialization(id);
            await _uow.SaveAsync();
            return Ok(id);
        }
    }
}