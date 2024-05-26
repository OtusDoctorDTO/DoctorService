using DoctorService.Domain.Entities;
using DoctorService.Domain.Helpers;
using Microsoft.EntityFrameworkCore;

namespace DoctorService.Data.Context
{
    //взаимодействие с базой данных.
    public class DoctorDbContext : DbContext
    {
        public DbSet<Doctor> Doctors { get; set; }
        public DbSet<Contact> Contacts { get; set; }
        public DbSet<Schedule> Schedules { get; set; } = null!;

        public DoctorDbContext(DbContextOptions<DoctorDbContext> options) : base(options)
        {
            Database.EnsureCreated();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var contact = new Contact
            {
                Id = Guid.NewGuid(),
                MobilePhone = "9010010101",
                HomePhone = "9010010102",
                Email = "doctor1@gmail.com",
            };
            var doctor = new Doctor()
            {
                Id = Guid.NewGuid(),
                LastName = "Иванов",
                FirstName = "Иван",
                MiddleName = "Иванович",
                Specialty = "Терапевт",
                ContactId = contact.Id,
            };

            modelBuilder.Entity<Contact>().HasData(Constants.Contacts);
            modelBuilder.Entity<Doctor>().HasData(Constants.Doctors);
        }
    }
}
