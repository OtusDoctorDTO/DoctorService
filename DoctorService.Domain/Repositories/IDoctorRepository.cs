using DoctorService.Domain.Entities;

namespace DoctorService.Domain.Repositories
{
    public interface IDoctorRepository
    {
        Task<Guid> AddDoctor(Doctor doctor);
        Task UpdateDoctor(Doctor doctor);
        Task DeleteDoctor(Guid doctorId);
        Task<Doctor?> GetDoctorById(Guid doctorId);
        Task<List<Doctor>> GetAll();
    }
}
