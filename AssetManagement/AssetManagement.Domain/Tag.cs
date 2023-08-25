using AssetManagement.Domain.Base;

namespace AssetManagement.Domain
{
    /// <summary>
    /// Tag entity for product
    /// </summary>
    public class Tag : Identity
    {
        /// <summary>
        /// Tag name
        /// </summary>
        public string Name { get; set; } = null!;

        /// <summary>
        /// Lined tags
        /// </summary>
        public virtual List<Product>? Products { get; set; }
    }
}