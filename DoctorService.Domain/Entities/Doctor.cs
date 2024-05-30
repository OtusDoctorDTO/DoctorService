namespace DoctorService.Domain.Entities
{
    public class Doctor
    {
        public Guid Id { get; set; }

        /// <summary>
        /// Фамилия
        /// </summary>
        public string? LastName { get; set; }

        /// <summary>
        /// Имя
        /// </summary>
        public string? FirstName { get; set; }

        /// <summary>
        /// Отчество
        /// </summary>
        public string? MiddleName { get; set; }

        /// <summary>
        /// Специальность
        /// </summary>
        public string? Specialty { get; set; }

        /// <summary>
        /// Дата начала трудовой деятельности
        /// </summary>
        public DateTime? StartDate { get; set; }
        public Guid? ContactId { get; set; }
        /// <summary>
        /// Контакты
        /// </summary>
        public virtual Contact? Contact { get; set; }

        /// <summary>
        /// График работы
        /// </summary>
        public virtual List<Schedule>? Schedules { get; set; }
    }
}
