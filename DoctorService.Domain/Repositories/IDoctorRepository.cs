using DoctorService.Domain.Entities;

namespace DoctorService.Domain.Repositories
{
    public interface IDoctorRepository
    {
        Task<Guid> AddDoctor(Doctor doctor);
        Task UpdateDoctor(Doctor doctor);
        Task DeleteDoctor(int doctorId);
        Task<Doctor?> GetDoctorById(int doctorId);
        Task<List<Doctor>> GetAllDoctors();
    }
}
