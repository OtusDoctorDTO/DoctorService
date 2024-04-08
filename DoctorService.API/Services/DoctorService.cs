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
        public async Task<Guid> Add(NewDoctorDTO doctor)
        {
            var doctorDB = doctor.ToDoctorDB();
            return await _repository.AddDoctor(doctorDB!);
        }

        public async Task<List<DoctorDTO?>?> GetAll()
        {
            var doctors = await _repository.GetAllDoctors();
            return doctors?.Select(doctor => doctor.ToDoctorDTO()).ToList();
        }

        public async Task<DoctorDTO?> GetById(int id)
        {
            var doctor = await _repository.GetDoctorById(id);
            return doctor?.ToDoctorDTO();
        }
    }
}
