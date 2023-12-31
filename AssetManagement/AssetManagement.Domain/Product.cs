using AssetManagement.Domain.Base;

namespace AssetManagement.Domain
{
    /// <summary>
    /// Product
    /// </summary>
    public class Product : Auditable, IPublished
    {
        /// <summary>
        /// Name
        /// </summary>
        public string Name { get; set; } = null!;

        /// <summary>
        /// Description
        /// </summary>
        public string? Description { get; set; }

        /// <summary>
        /// Category identifier
        /// </summary>
        public Guid CategoryId { get; set; }

        /// <summary>
        /// Category
        /// </summary>
        public virtual Category? Category { get; set; }

        /// <summary>
        /// Price
        /// </summary>
        public int? Price { get; set; }


        /// <summary>
        /// Lined tags
        /// </summary>
        public virtual List<Tag>? Tags { get; set; }

        /// <summary>
        /// Indicate that the entity visible
        /// </summary>
        public bool Visible { get; set; }
    }
}