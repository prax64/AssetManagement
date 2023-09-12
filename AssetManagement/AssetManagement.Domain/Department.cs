using AssetManagement.Domain.Base;

namespace AssetManagement.Domain
{
    public class Department : Identity
    {
        /// <summary>
        /// Имя отдела
        /// </summary>
        public string Name { get; set; } = null!;

        /// <summary>
        /// Описание отдела
        /// </summary>
        public string? Description { get; set; }

        /// <summary>
        /// Люди в текущем отделе
        /// </summary>
        public virtual List<User>? Users { get; set; }
    }
}
