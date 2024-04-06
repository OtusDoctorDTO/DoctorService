using DoctorService.Domain.Entities;

namespace DoctorService.Domain.Services
{
    public interface IDoctorService
    {
        IEnumerable<Doctor> GetAllDoctors();
        Doctor GetDoctorById(int id);
        void AddDoctor(Doctor patient);

    }
}
