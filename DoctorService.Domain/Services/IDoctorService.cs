using DoctorService.Domain.Entities;
using HelpersDTO.Doctor.DTO;
using HelpersDTO.Doctor.DTO.Models;

namespace DoctorService.Domain.Services
{
    public interface IDoctorService
    {
        Task<IEnumerable<DoctorDTO>?> GetAllDoctors();
        Task<DoctorDTO?> GetDoctorById(int id);
        Task AddDoctor(DoctorDTO doctor);
    }
}
