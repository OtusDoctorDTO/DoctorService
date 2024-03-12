using DoctorService.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoctorService.Domain.Services
{
    public class DoctorService
    {
        private readonly List<Doctor> _doctors;

        public DoctorService()
        {
            _doctors = new List<Doctor>();
        }

        public void AddDoctor(Doctor doctor)
        {
            _doctors.Add(doctor);
        }

        public List<Doctor> GetDoctors()
        {
            return _doctors;
        }

    }
}
