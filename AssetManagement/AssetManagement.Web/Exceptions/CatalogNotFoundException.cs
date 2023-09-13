using System.Runtime.Serialization;

namespace AssetManagement.Web.Exceptions
{
    [Serializable]
    internal class CatalogNotFoundException : Exception
    {
        public CatalogNotFoundException()
        {
        }

        public CatalogNotFoundException(string? message) : base(message)
        {
        }

        public CatalogNotFoundException(string? message, Exception? innerException) : base(message, innerException)
        {
        }

        protected CatalogNotFoundException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}