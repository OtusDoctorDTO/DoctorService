using DoctorService.Domain.Entities;
using HelpersDTO.Doctor.DTO.Models;

namespace DoctorService.Domain.Repositories
{
    public interface IDoctorRepository
    {
        Task<Guid> AddDoctor(Doctor doctor);
        Task UpdateDoctor(Doctor doctor);
        Task DeleteDoctor(Guid doctorId);
        Task<Doctor?> GetDoctorById(Guid doctorId);
        Task<List<Doctor>> GetAll();
        Task<List<Doctor>?> GetByIds(Guid[] ids);
    }
}
