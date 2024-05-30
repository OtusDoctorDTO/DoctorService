using HelpersDTO.Doctor.DTO.Models;

namespace DoctorService.Domain.Services
{
    public interface IDoctorService
    {
        Task<Guid> Add(NewDoctorDTO doctor);
        Task<List<DoctorDTO?>?> GetAll();
        Task<DoctorDTO?> GetById(Guid id);
        Task<FullInfoDoctorDTO?> GetFullInfoById(Guid id);
        Task<List<DoctorDTO>> GetByIds(Guid[] ids);
    }
}
