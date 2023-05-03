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
    public class MedicController : ControllerBase
    {
        private readonly IUnitOfWork _uow;
        private readonly IMapper _mapper;

        public MedicController(IUnitOfWork uow, IMapper mapper)
        {
            _uow = uow;
            _mapper = mapper;
        }

        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> GetMedics()
        {
            var medics = await _uow.MedicRepository.GetMedicsAsync();
            var medicsDto = _mapper.Map<IEnumerable<MedicDto>>(medics);
            return Ok(medicsDto);
        }

        [HttpGet("{id:int}")]
        public ActionResult<MedicDto> GetMedicById(int Id)
        {
            var medics = _uow.MedicRepository.GetMedicById(Id);
            var medicsDto = _mapper.Map<IEnumerable<MedicDto>>(medics);
            return Ok(medicsDto);
        }

        [HttpPost]
        public async Task<IActionResult> CreateMedic(MedicDto medicDto)
        {
            var medic = _mapper.Map<Medic>(medicDto);
            _uow.MedicRepository.CreateMedic(medic);
            await _uow.SaveAsync();
            return StatusCode(201);
        }

        //[HttpDelete("{id:int}")]
        //public ActionResult<Medic> UpdateMedic(int Id, Medic medic)
        //{
        //    try
        //    {
        //        if (Id != medic.Id)
        //            return BadRequest("Medic ID mismatch");

        //        var updateMedic =  _medicRepository.CreateMedic(medic);

        //        return CreatedAtAction(nameof(GetMedicById),
        //            new { id = updateMedic.Id }, updateMedic);
        //    }
        //    catch (Exception)
        //    {
        //        return StatusCode(StatusCodes.Status500InternalServerError,
        //            "Error creating new medic record");
        //    }
        //}

        //public IActionResult DeleteMedic(int Id)
        //{
        //    try
        //    {
        //        var deleteMedic =  _medicRepository.GetMedicByID(Id);

        //        if (deleteMedic == null)
        //        {
        //            return NotFound($"Medic with Id = {Id} not found");
        //        }

        //         _medicRepository.DeleteMedic(Id);

        //        return Ok($"Medic with Id = {Id} not found");
        //    }
        //    catch (Exception)
        //    {
        //        return StatusCode(StatusCodes.Status500InternalServerError,
        //            "Error delete medic record");
        //    }
        //}
    }
}