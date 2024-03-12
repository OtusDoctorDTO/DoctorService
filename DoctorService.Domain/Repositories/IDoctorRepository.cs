using System.Collections.Generic;
using DoctorService.Domain.Entities;

namespace DoctorService.Domain.Repositories
{
    public interface IDoctorRepository
    {
        void AddDoctor(Doctor doctor);
        void UpdateDoctor(Doctor doctor);
        void DeleteDoctor(int doctorId);
        Doctor GetDoctorById(int doctorId);
        List<Doctor> GetAllDoctors();
    }
}
