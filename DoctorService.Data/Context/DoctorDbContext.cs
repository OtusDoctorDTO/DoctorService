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
            modelBuilder.Entity<Contact>().HasData(Constants.Contacts);
            modelBuilder.Entity<Doctor>().HasData(Constants.Doctors);
            modelBuilder.Entity<Schedule>().HasData(Constants.Schedules);
        }
    }
}
