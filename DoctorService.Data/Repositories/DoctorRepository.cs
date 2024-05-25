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

        public async Task<Guid> AddDoctor(Doctor doctor)
        {
            _dbContext.Doctors.Add(doctor);
            await _dbContext.SaveChangesAsync();
            return doctor.Id;
        }

        public async Task UpdateDoctor(Doctor doctor)
        {
            _dbContext.Doctors.Update(doctor);
            await _dbContext.SaveChangesAsync();
        }

        public async Task DeleteDoctor(Guid doctorId)
        {
            var doctor = await _dbContext.Doctors.FindAsync(doctorId);
            if (doctor != null)
            {
                _dbContext.Doctors.Remove(doctor);
                await _dbContext.SaveChangesAsync();
            }
        }

        public async Task<Doctor?> GetDoctorById(Guid doctorId)
        {
            return await _dbContext.Doctors
                .Include(d => d.Contact)
                .FirstOrDefaultAsync(d => d.Id == doctorId);
        }

        public async Task<List<Doctor>> GetAll()
        {
            return await _dbContext.Doctors
                .Include(d => d.Contact)
                .ToListAsync();
        }

        public async Task<List<Doctor>?> GetByIds(Guid[] ids)
        {
            return await _dbContext.Doctors
                .Include(d => d.Contact)
                .AsNoTracking()
                .Where(doc=> ids.Contains(doc.Id))
                .ToListAsync();
        }
    }
}
