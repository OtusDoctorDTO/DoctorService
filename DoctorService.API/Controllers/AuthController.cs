using Microsoft.AspNetCore.Mvc;
using DoctorService.API.Models;
using DoctorService.API.Services;

namespace DoctorService.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly AuthService _authService;

        public AuthController(AuthService authService)
        {
            _authService = authService;
        }

    }
}
