using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssetManagement.Web.Exceptions
{
    public class CatalogDatabaseSaveException : Exception
    {
        public CatalogDatabaseSaveException(string? messege)
            : base(messege) { }

        public CatalogDatabaseSaveException(string? messege, Exception? exception)
            : base(messege, exception) { }
    }
}
