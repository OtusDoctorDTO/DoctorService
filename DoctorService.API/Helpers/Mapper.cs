using DoctorService.Domain.Entities;
using HelpersDTO.Base.Models;
using HelpersDTO.Doctor.DTO.Models;

namespace DoctorService.API.Helpers
{
    public static class Mapper
    {
        public static DoctorDTO? ToDoctorDTO(this Doctor doctor)
        {
            if (doctor == null) return null;
            return new DoctorDTO()
            {
                Id = doctor.Id,
                User = new BaseUserDTO()
                {
                    LastName = doctor!.LastName ?? "",
                    FirstName = doctor!.FirstName ?? "",
                    MiddleName = doctor!.MiddleName ?? ""
                },
                Specialty = doctor!.Specialty
            };
        }

        public static Doctor? ToDoctorDB(this DoctorDTO doctor)
        {
            if (doctor == null) return null;
            return new Doctor()
            {
                Id = doctor.Id,
                FirstName = doctor.User?.FirstName,
                LastName = doctor.User?.LastName,
                MiddleName = doctor.User?.MiddleName,
                Specialty = doctor.Specialty
            };
        }

        public static Doctor? ToDoctorDB(this NewDoctorDTO doctor)
        {
            if (doctor == null) return null;
            return new Doctor()
            {
                FirstName = doctor.User?.FirstName,
                LastName = doctor.User?.LastName,
                MiddleName = doctor.User?.MiddleName,
                Specialty = doctor.Specialty
            };
        }
    }
}
