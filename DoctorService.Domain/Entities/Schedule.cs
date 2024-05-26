namespace DoctorService.Domain.Entities
{
    public class Schedule
    {
        public Guid Id { get; set; }
        public Guid DoctorId { get; set; }

        /// <summary>
        /// Кабинет
        /// </summary>
        public Guid? CabinetId { get; set; }
        /// <summary>
        /// Дата работы
        /// </summary>
        public DateOnly Date { get; set; }

        /// <summary>
        /// Время начала
        /// </summary>
        public TimeOnly SinceTime { get; set; }

        /// <summary>
        /// Время окончания
        /// </summary>
        public TimeOnly ForTime { get; set; }
        public virtual Doctor? Doctor { get; set; }
    }
}
