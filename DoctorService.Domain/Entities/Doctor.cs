namespace DoctorService.Domain.Entities
{
    public class Doctor
    {
        public int Id { get; set; }

        /// <summary>
        /// Фамилия
        /// </summary>
        public string LastName { get; set; }
        /// <summary>
        /// Имя
        /// </summary>
        public string FirstName { get; set; }
        /// <summary>
        /// Отчество
        /// </summary>
        public string? MiddleName { get; set; }

        /// <summary>
        /// Специальность
        /// </summary>
        public string Specialty { get; set; }
    }
}
