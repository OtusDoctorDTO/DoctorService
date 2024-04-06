using DoctorService.Domain.Entities;

namespace DoctorService.Domain.Services
{
    public class IAppointmentService
    {
        private readonly List<Appointment> _appointments;

        public IAppointmentService()
        {
            _appointments = new List<Appointment>();
        }

        public void ScheduleAppointment(Appointment appointment)
        {
            _appointments.Add(appointment);
        }

        public List<Appointment> GetAppointmentsForDoctor(int doctorId)
        {
            return _appointments.FindAll(a => a.DoctorId == doctorId);
        }

    }
}
