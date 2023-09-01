using AssetManagement.Domain;
using AssetManagement.Infrastructure.ModelConfigurations.Base;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssetManagement.Infrastructure.ModelConfigurations
{
    public class QRcodeModelConfiguration : IdentityModelConfigurationBase<QRcode>
    {
        /// <inheritdoc />
        protected override void AddBuilder(EntityTypeBuilder<QRcode> builder)
        {
            builder.Property(x => x.QRCode).IsRequired();

        }

        /// <inheritdoc />
        protected override string TableName()
        {
            return "QRcode";
        }
    }
    
}
