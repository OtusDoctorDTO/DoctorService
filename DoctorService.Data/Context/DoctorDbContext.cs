using Microsoft.EntityFrameworkCore;
using DoctorService.Domain.Entities;

namespace DoctorService.Data.Context
{
    //взаимодействие с базой данных.
    public class DoctorDbContext : DbContext
    {
        public DbSet<Doctor> Doctors { get; set; }
        public DbSet<Contact> Contacts { get; set; }
        

        public DoctorDbContext(DbContextOptions<DoctorDbContext> options) : base(options)
        {
            Database.EnsureCreated();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Doctor>()
                .HasOne(e => e.Contact)
                .WithOne(e => e.Doctor)
                .HasForeignKey<Doctor>(e => e.ContactId)
                .IsRequired();
        }
    }
}
