using DoctorService.API.Helpers;
using DoctorService.Domain.Repositories;
using DoctorService.Domain.Services;
using HelpersDTO.Doctor.DTO.Models;

namespace DoctorService.API.Services
{
    public class DoctorService : IDoctorService
    {
        private readonly IDoctorRepository _repository;
        public DoctorService(IDoctorRepository repository)
        {
            _repository = repository;
        }
        public async Task AddDoctor(DoctorDTO doctor)
        {
            var doctorDB = doctor.ToDoctorDB();
            _repository.AddDoctor(doctorDB);
        }

        public async Task<IEnumerable<DoctorDTO>?> GetAllDoctors()
        {
            var doctors = await _repository.GetAllDoctors();
            return doctors?.Select(doctor => doctor.ToDoctorDTO());
        }

        public async Task<DoctorDTO?> GetDoctorById(int id)
        {
            var doctor = await _repository.GetDoctorById(id);
            return doctor?.ToDoctorDTO();
        }
    }
}
