﻿using DoctorService.Domain.Entities;
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

        [HttpGet]
        public async Task<ActionResult<IEnumerable<DoctorDTO>>> GetAllDoctors()
        {
            try
            {
                var doctors = await _doctorService.GetAllDoctors();

                return Ok(doctors);
            }
            catch (Exception e)
            {
                _logger.LogError(e.Message);
                return BadRequest("Произошла ошибка");
            }
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Doctor>> GetDoctorById(int id)
        {
            try
            {
                var doctor = await _doctorService.GetDoctorById(id);
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

    }
}
