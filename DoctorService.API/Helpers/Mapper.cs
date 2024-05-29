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
                Specialty = doctor!.Specialty ?? "",
                 Contacts = new ContactDTO()
                 {
                     Email = doctor.Contact?.Email ?? "",
                     HomePhone = doctor.Contact?.HomePhone?? "",
                     MobilePhone = doctor.Contact!?.MobilePhone ?? ""
                 }
            };
        }

        public static FullInfoDoctorDTO? ToFullDoctorDTO(this Doctor doctor)
        {
            if (doctor == null) return null;
            return new FullInfoDoctorDTO()
            {
                Id = doctor.Id,
                UserInfo = new BaseUserDTO()
                {
                    LastName = doctor!.LastName ?? "",
                    FirstName = doctor!.FirstName ?? "",
                    MiddleName = doctor!.MiddleName ?? ""
                },
                // Cabinet = 
                 StartWorkDate = doctor.StartDate,
                  IntervalInfo = doctor.Schedules?
                  .ToDictionary(schedule => schedule.Date, schedule => new IntervalDTO() 
                  { 
                      ForTime = schedule.ForTime, 
                      SinceTime = schedule.SinceTime
                  } ?? null) ?? null,
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
                Specialty = doctor.Specialty,
                Contact = new Contact()
                {
                    Email = doctor.Contacts.Email,
                    HomePhone = doctor.Contacts.HomePhone,
                    MobilePhone = doctor.Contacts.MobilePhone
                }

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
                Specialty = doctor.Specialty,
                Contact = new Contact()
                {
                    Email = doctor.Contacts?.Email ?? "",
                    HomePhone = doctor.Contacts?.HomePhone ?? "",
                    MobilePhone = doctor.Contacts?.MobilePhone ?? "",
                }
            };
        }
    }
}
