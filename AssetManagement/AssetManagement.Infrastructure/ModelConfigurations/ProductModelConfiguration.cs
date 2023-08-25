using AssetManagement.Domain;
using AssetManagement.Infrastructure.ModelConfigurations.Base;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AssetManagement.Infrastructure.ModelConfigurations
{
    /// <summary>
    /// Entity Type Configuration for entity <see cref="Product"/>
    /// </summary>
    public class ProductModelConfiguration : AuditableModelConfigurationBase<Product>
    {
        /// <inheritdoc />
        protected override void AddBuilder(EntityTypeBuilder<Product> builder)
        {
            builder.Property(x => x.Name).HasMaxLength(128).IsRequired();
            builder.Property(x => x.Description).HasMaxLength(2048);
            builder.Property(x => x.Price);
            builder.Property(x => x.Visible);
            builder.Property(x => x.CategoryId).IsRequired();

            builder.HasOne(x => x.Category);
        }

        /// <inheritdoc />
        protected override string TableName()
        {
            return "Products";
        }
    }
}