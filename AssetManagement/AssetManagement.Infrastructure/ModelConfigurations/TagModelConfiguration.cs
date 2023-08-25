using AssetManagement.Domain;
using AssetManagement.Infrastructure.ModelConfigurations.Base;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AssetManagement.Infrastructure.ModelConfigurations
{
    /// <summary>
    /// Entity Type Configuration for entity <see cref="Tag"/>
    /// </summary>
    public class TagModelConfiguration : IdentityModelConfigurationBase<Tag>
    {
        /// <inheritdoc />
        protected override void AddBuilder(EntityTypeBuilder<Tag> builder)
        {
            builder.Property(x => x.Name).HasMaxLength(50).IsRequired();

        }

        /// <inheritdoc />
        protected override string TableName()
        {
            return "Tags";
        }
    }
}