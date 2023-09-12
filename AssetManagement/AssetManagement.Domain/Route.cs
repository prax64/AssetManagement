using AssetManagement.Domain.Base;

namespace AssetManagement.Domain
{
    /// <summary>
    /// Маршрут
    /// </summary>
    public class Route : Identity
    {
        /// <summary>
        /// Имя маршрута
        /// </summary>
        public string Name { get; set; } = null!;

        /// <summary>
        /// Описание маршрута
        /// </summary>
        public string? Description { get; set; }

        /// <summary>
        /// Id стадии маршрута
        /// </summary>
        public Guid StageId { get; set; }

        /// <summary>
        /// Список отделов
        /// </summary>
        public virtual List<Department>? Departments { get; set; }



    }
}
