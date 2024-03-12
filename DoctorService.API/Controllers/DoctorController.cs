using Microsoft.AspNetCore.Mvc;
using DoctorService.API.Models;
using DoctorService.API.Services;

namespace DoctorService.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DoctorController : ControllerBase
    {
        private readonly DoctorService _doctorService;

        public DoctorController(DoctorService doctorService)
        {
            _doctorService = doctorService;
        }

    }
}
