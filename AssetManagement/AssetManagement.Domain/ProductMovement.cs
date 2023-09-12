using AssetManagement.Domain.Base;

namespace AssetManagement.Domain
{
    /// <summary>
    /// Движение продукта
    /// </summary>
    public class ProductMovement : Auditable
    {
        /// <summary>
        /// Текущий отдел
        /// </summary>
        public Guid CurrentDepartment { get; set; }

        /// <summary>
        /// Текущая стадия
        /// </summary>
        public Guid CurrentStageId { get; set; }

        /// <summary>
        /// Пользователь отправивший продукт по маршруту
        /// </summary>
        public Guid RecipientUserId { get; set; }  


        ///// <summary>
        ///// Лицо 
        ///// </summary>
        //public Guid SenderUserId { get; set; }

        public Guid ProductId { get; set; }

        public Guid RouteId { get; set; }

    }
}
