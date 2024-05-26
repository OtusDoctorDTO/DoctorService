using DoctorService.Domain.Entities;

namespace DoctorService.Domain.Helpers
{
    public static class Constants
    {
        private static DateTime now = DateTime.Now;
        public static Contact[] Contacts = new Contact[]
        {
            new()
            {
                Id = Guid.Parse("b156e489-5868-4841-85ca-9560a6253c75"),
                MobilePhone = "9010010101",
                HomePhone = "9010010102",
                Email = "doctor1@gmail.com",
            },
            new()
            {
                Id = Guid.Parse("6d26a4c7-e43b-4496-b214-6e9920bab3b0"),
                MobilePhone = "9010010103",
                HomePhone = "9010010104",
                Email = "doctor2@gmail.com",
            },
            new()
            {
                Id = Guid.Parse("1c31d795-3a3a-4c4c-9092-dc0370f21bf9"),
                MobilePhone = "9010010105",
                HomePhone = "9010010106",
                Email = "doctor3@gmail.com",
            },

            new()
            {
                Id = Guid.Parse("f8c0cce0-7f63-4a6c-9812-56994e7f6175"),
                MobilePhone = "9010010107",
                HomePhone = "9010010108",
                Email = "doctor4@gmail.com",
            },
            new()
            {
                Id = Guid.Parse("3476e001-352b-44d0-bd26-57960baa4b4d"),
                MobilePhone = "9010010109",
                HomePhone = "9010010110",
                Email = "doctor5@gmail.com",
            }
        };
        public static Doctor[] Doctors = new Doctor[]
{
            new()
            {
                Id = Guid.Parse("61dd8fe5-aed3-44af-a451-823caeb2dc68"),
                LastName = "Иванов",
                FirstName = "Иван",
                MiddleName = "Иванович",
                Specialty = "Терапевт",
                StartDate = DateTime.Now.AddYears(-2),
                ContactId = Contacts[0].Id
            },
            new()
            {
                Id = Guid.Parse("c302105d-1c7e-4db4-9380-d91146596f05"),
                LastName = "Петров",
                FirstName = "Петр",
                MiddleName = "Петрович",
                Specialty = "Терапевт",
                StartDate = DateTime.Now.AddYears(-3),
                ContactId = Contacts[1].Id
            },
            new()
            {
                Id = Guid.Parse("eec214ba-7605-4392-9ec4-e788ded53bea"),
                LastName = "Сидоров",
                FirstName = "Семен",
                MiddleName = "Семенович",
                Specialty = "Терапевт",
                StartDate = DateTime.Now.AddYears(-4),
                ContactId = Contacts[2].Id
            },

            new()
            {
                Id = Guid.Parse("a372bf3d-efe9-4f0d-b16b-ac550a3947d2"),
                LastName = "Кузнецов",
                FirstName = "Иван",
                MiddleName = "Петрович",
                Specialty = "Терапевт",
                StartDate = DateTime.Now.AddYears(-5),
                ContactId = Contacts[3].Id
            },
            new()
            {
                Id = Guid.Parse("c5508ee0-fbe6-47fa-b7d3-d6438b93b43d"),
                LastName = "Яковлев",
                FirstName = "Алексай",
                MiddleName = "Иванович",
                Specialty = "Терапевт",
                StartDate = DateTime.Now.AddYears(-6),
                ContactId = Contacts[4].Id
            }
};
        public static Schedule[] Schedules = new Schedule[]
        {
            new()
            {
                Id = Guid.NewGuid(),
                Date = new DateOnly(now.Year, now.Month, now.Day),
                SinceTime = new TimeOnly(9,0),
                ForTime = new TimeOnly(14,0),
                DoctorId = Doctors[0].Id
            },
            new()
            {
                Id = Guid.NewGuid(),
                Date = new DateOnly(now.Year, now.Month, now.AddDays(1).Day),
                SinceTime = new TimeOnly(9,0),
                ForTime = new TimeOnly(14,0),
                DoctorId = Doctors[1].Id
            },
            new()
            {
                Id = Guid.NewGuid(),
                Date = new DateOnly(now.Year, now.Month, now.AddDays(2).Day),
                SinceTime = new TimeOnly(9,0),
                ForTime = new TimeOnly(14,0),
                DoctorId = Doctors[2].Id
            },
            new()
            {
                Id = Guid.NewGuid(),
                Date = new DateOnly(now.Year, now.Month, now.AddDays(3).Day),
                SinceTime = new TimeOnly(9,0),
                ForTime = new TimeOnly(14,0),
                DoctorId = Doctors[3].Id
            },
            new()
            {
                Id = Guid.NewGuid(),
                Date = new DateOnly(now.Year, now.Month, now.AddDays(4).Day),
                SinceTime = new TimeOnly(9,0),
                ForTime = new TimeOnly(14,0),
                DoctorId = Doctors[4].Id
            },
            new()
            {
                Id = Guid.NewGuid(),
                Date = new DateOnly(now.Year, now.Month, now.AddDays(5).Day),
                SinceTime = new TimeOnly(9,0),
                ForTime = new TimeOnly(14,0),
                DoctorId = Doctors[0].Id
            },
            new()
            {
                Id = Guid.NewGuid(),
                Date = new DateOnly(now.Year, now.Month, now.AddDays(6).Day),
                SinceTime = new TimeOnly(9,0),
                ForTime = new TimeOnly(14,0),
                DoctorId = Doctors[1].Id
            },
            new()
            {
                Id = Guid.NewGuid(),
                Date = new DateOnly(now.Year, now.Month, now.AddDays(7).Day),
                SinceTime = new TimeOnly(9,0),
                ForTime = new TimeOnly(14,0),
                DoctorId = Doctors[2].Id
            }
        };
    }
}
