using DoctorService.Domain.Entities;
using HelpersDTO.Doctor.DTO;

namespace DoctorService.Domain.Services
{
    public interface IDoctorService
    {
        Task<IEnumerable<DoctorDTO>?> GetAllDoctors();
        Task<DoctorDTO?> GetDoctorById(int id);
        Task AddDoctor(DoctorDTO doctor);
    }
}
