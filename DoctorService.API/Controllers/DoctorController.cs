using DoctorService.API.Helpers;
using DoctorService.Domain.Entities;
using DoctorService.Domain.Services;
using HelpersDTO.Doctor.DTO;
using Microsoft.AspNetCore.Mvc;

namespace DoctorService.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DoctorController : ControllerBase
    {
        private readonly IDoctorService _doctorService;
        private readonly ILogger<DoctorController> _logger;

        public DoctorController(IDoctorService doctorService, ILogger<DoctorController> logger)
        {
            _doctorService = doctorService;
            _logger = logger;
        }

        [HttpGet]
        public ActionResult<IEnumerable<DoctorDTO>> GetAllDoctors()
        {
            try
            {
                var doctors = _doctorService.GetAllDoctors();
                var doctorsDTO = doctors.Select(doctor => doctor.ToDoctorDTO()).ToList();

                return Ok(doctorsDTO);
            }
            catch (Exception e)
            {
                _logger.LogError(e);
                return BadRequest("Произошла ошибка");
            }
        }

        [HttpGet("{id}")]
        public ActionResult<Doctor> GetDoctorById(int id)
        {
            try
            {
                var doctor = _doctorService.GetDoctorById(id);
                if (doctor == null)
                {
                    return NotFound();
                }
                return Ok(doctor.ToDoctorDTO());
            }
            catch (Exception e)
            {
                _logger.LogError(e);
                return BadRequest("Произошла ошибка");
            }
        }

    }
}
