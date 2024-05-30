namespace DoctorService.Domain.Entities
{
    /// <summary>
    /// Контакты
    /// </summary>
    public class Contact
    {
        public Guid Id { get; set; }
        /// <summary>
        /// Мобильный телефон
        /// </summary>
        public string? MobilePhone { get; set; }
        /// <summary>
        /// Домашний телефон
        /// </summary>
        public string? HomePhone { get; set; }
        /// <summary>
        /// Электронная почта
        /// </summary>
        public string? Email { get; set; }
        public virtual Doctor? Doctor { get; set; }
    }
}
