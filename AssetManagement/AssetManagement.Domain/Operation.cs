using AssetManagement.Domain.Base;

namespace AssetManagement.Domain
{
    /// <summary>
    /// Операция над продуктом
    /// </summary>
    public class Operation : Identity
    {
        /// <summary>
        /// Имя операции
        /// </summary>
        public string Name { get; set; } = null!;

        /// <summary>
        /// Описание операции
        /// </summary>
        public string? Description { get; set; }
    }
}
