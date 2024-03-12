using DoctorService.Data.Context;
using DoctorService.Domain.Entities;
using DoctorService.Domain.Repositories;

namespace DoctorService.Data.Repositories
{
    public class AppointmentRepository : IAppointmentRepository
    {
        private readonly DoctorDbContext _dbContext;

        public AppointmentRepository(DoctorDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void ScheduleAppointment(Appointment appointment)
        {
            _dbContext.Appointments.Add(appointment);
            _dbContext.SaveChanges();
        }

        public void CancelAppointment(int appointmentId)
        {
            var appointment = _dbContext.Appointments.Find(appointmentId);
            if (appointment != null)
            {
                _dbContext.Appointments.Remove(appointment);
                _dbContext.SaveChanges();
            }
        }

        public Appointment GetAppointmentById(int appointmentId)
        {
            return _dbContext.Appointments.Find(appointmentId);
        }
        public List<Appointment> GetAppointmentsForDoctor(int doctorId)
        {
            return _dbContext.Appointments.Where(a => a.DoctorId == doctorId).ToList();
        }

        public List<Appointment> GetAllAppointments()
        {
            return _dbContext.Appointments.ToList();
        }
    }
}
