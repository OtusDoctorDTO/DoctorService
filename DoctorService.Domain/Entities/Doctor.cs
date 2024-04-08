﻿namespace DoctorService.Domain.Entities
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

        public Guid ContactId { get; set; }

        /// <summary>
        /// Контакты
        /// </summary>
        public virtual Contact Contact { get; set; }
    }
}
