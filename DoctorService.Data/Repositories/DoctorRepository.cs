using DoctorService.Data.Context;
using DoctorService.Domain.Entities;
using DoctorService.Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace DoctorService.Data.Repositories
{
    public class DoctorRepository : IDoctorRepository
    {
        private readonly DoctorDbContext _dbContext;

        public DoctorRepository(DoctorDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task AddDoctor(Doctor doctor)
        {
            _dbContext.Doctors.Add(doctor);
            await _dbContext.SaveChangesAsync();
        }

        public async Task UpdateDoctor(Doctor doctor)
        {
            _dbContext.Doctors.Update(doctor);
            await _dbContext.SaveChangesAsync();
        }

        public async Task DeleteDoctor(int doctorId)
        {
            var doctor = await _dbContext.Doctors.FindAsync(doctorId);
            if (doctor != null)
            {
                _dbContext.Doctors.Remove(doctor);
                await _dbContext.SaveChangesAsync();
            }
        }

        public async Task<Doctor?> GetDoctorById(int doctorId)
        {
            return await _dbContext.Doctors.FindAsync(doctorId);
        }

        public async Task<List<Doctor>> GetAllDoctors()
        {
            return await _dbContext.Doctors.ToListAsync();
        }
    }
}
