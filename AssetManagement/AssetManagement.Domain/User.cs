using AssetManagement.Domain.Base;

namespace AssetManagement.Domain
{
    /// <summary>
    /// Пользователь
    /// </summary>
    public class User : Identity
    {
        /// <summary>
        /// Email
        /// </summary>
        public string Email { get; set; } = null!;

        /// <summary>
        /// Ник
        /// </summary>
        public string UserName { get; set; } = null!;

        /// <summary>
        /// Имя
        /// </summary>
        public string Name { get; set; } = null!;


        /// <summary>
        /// Номер телефона
        /// </summary>
        public string PhoneNumber { get; set; } = null!;

        /// <summary>
        /// Идентификатор отдела
        /// </summary>
        public Guid DepartmentId { get; set; }
    }
}
