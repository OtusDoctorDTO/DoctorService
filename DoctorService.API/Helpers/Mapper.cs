using DoctorService.Domain.Entities;
using HelpersDTO.Doctor.DTO;

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
                    LastName = doctor.LastName,
                    FirstName = doctor.FirstName,
                    MiddleName = doctor.MiddleName
                },
                Specialty = doctor.Specialty
            };
        }

        public static Doctor? ToDoctorDB(this DoctorDTO doctor)
        {
            if (doctor == null) return null;
            return new Doctor()
            {
                Id = ,
                FirstName = doctor.,
                LastName = ,
                MiddleName = ,
                Specialty =
            };
        }
    }
}
