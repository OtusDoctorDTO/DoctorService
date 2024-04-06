using DoctorService.Domain.Entities;
using DoctorService.Domain.Repositories;
using DoctorService.Data.Context;

namespace DoctorService.Data.Repositories
{
    public class DoctorRepository : IDoctorRepository
    {
        private readonly DoctorDbContext _dbContext;

        public DoctorRepository(DoctorDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void AddDoctor(Doctor doctor)
        {
            _dbContext.Doctors.Add(doctor);
            _dbContext.SaveChanges();
        }

        public void UpdateDoctor(Doctor doctor)
        {
            _dbContext.Doctors.Update(doctor);
            _dbContext.SaveChanges();
        }

        public void DeleteDoctor(int doctorId)
        {
            var doctor = _dbContext.Doctors.Find(doctorId);
            if (doctor != null)
            {
                _dbContext.Doctors.Remove(doctor);
                _dbContext.SaveChanges();
            }
        }

        public Doctor GetDoctorById(int doctorId)
        {
            return _dbContext.Doctors.Find(doctorId);
        }

        public List<Doctor> GetAllDoctors()
        {
            return _dbContext.Doctors.ToList();
        }
    }
}
