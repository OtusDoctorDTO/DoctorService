using System.Collections.Generic;
using DoctorService.Domain.Entities;

namespace DoctorService.Domain.Repositories
{
    public interface IAppointmentRepository
    {
        void ScheduleAppointment(Appointment appointment);
        void CancelAppointment(int appointmentId);
        Appointment GetAppointmentById(int appointmentId);
        List<Appointment> GetAppointmentsForDoctor(int doctorId);
        List<Appointment> GetAllAppointments();
    }
}
