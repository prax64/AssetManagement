using AssetManagement.Domain.Base;

namespace AssetManagement.Domain
{
    /// <summary>
    /// Стадия маршрута
    /// </summary>
    public class Stage : Identity
    {
        /// <summary>
        /// Имя стадии
        /// </summary>
        public string Name { get; set; } = null!;

        /// <summary>
        /// Описание стадии
        /// </summary>
        public string? Description { get; set; }
    }
}
