using AssetManagement.Domain.Base;

namespace AssetManagement.Domain
{
    /// <summary>
    /// QRcode for products
    /// </summary>
    public class QRcode : Identity
    {
        /// <summary>
        /// QRcode
        /// </summary>
        public string QRCode { get; set; } = null!;
    }
}
