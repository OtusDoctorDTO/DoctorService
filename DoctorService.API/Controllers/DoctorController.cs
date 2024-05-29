using DoctorService.Domain.Entities;
using DoctorService.Domain.Services;
using HelpersDTO.Doctor.DTO.Models;
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

        /// <summary>
        /// Получить всех докторов
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<DoctorDTO>>> GetAllDoctors()
        {
            try
            {
                var doctors = await _doctorService.GetAll();

                return Ok(doctors);
            }
            catch (Exception e)
            {
                _logger.LogError(e.Message);
                return BadRequest("Произошла ошибка");
            }
        }

        /// <summary>
        /// Получить доктора по id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public async Task<ActionResult<Doctor>> GetDoctorById(Guid id)
        {
            try
            {
                var doctor = await _doctorService.GetById(id);
                if (doctor == null)
                {
                    return NotFound();
                }
                return Ok(doctor);
            }
            catch (Exception e)
            {
                _logger.LogError(e.Message);
                return BadRequest("Произошла ошибка");
            }
        }

        /// <summary>
        /// Добавить доктора
        /// </summary>
        /// <param name="doctor">Доктор</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        [HttpPost("Add")]
        public async Task<ActionResult<Guid>> AddNewDoctor(NewDoctorDTO doctor)
        {
            try
            {
                if (doctor == null)
                    throw new ArgumentNullException(nameof(doctor));
                var result = await _doctorService.Add(doctor!);
                return Ok(result);
            }
            catch (Exception e)
            {
                _logger.LogError(e.Message);
                return BadRequest("Произошла ошибка");
            }
        }

        /// <summary>
        /// Получить докторов по скиску id
        /// </summary>
        /// <returns></returns>
        [HttpPost("GetDoctorsByIds")]
        public async Task<ActionResult<IEnumerable<DoctorDTO>>> GetDoctorsByIds(Guid[] guids)
        {
            try
            {
                var doctors = await _doctorService.GetByIds(guids);
                return Ok(doctors);
            }
            catch (Exception e)
            {
                _logger.LogError(e.Message);
                return BadRequest("Произошла ошибка");
            }
        }

        /// <summary>
        /// Получить подробную информацию по id
        /// </summary>
        /// <returns></returns>
        [HttpPost("GetFullInfoById")]
        public async Task<ActionResult<IEnumerable<DoctorDTO>>> GetFullInfoByIdAsync(Guid id)
        {
            try
            {
                var doctor = await _doctorService.GetFullInfoById(id);
                return Ok(doctor);
            }
            catch (Exception e)
            {
                _logger.LogError(e.Message);
                return BadRequest("Произошла ошибка");
            }
        }
    }
}
