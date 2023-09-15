using LAB_API.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LAB_API.Mapping
{
    public class LabMap : IEntityTypeConfiguration<Lab>
    {
        public void Configure(EntityTypeBuilder<Lab> builder)
        {
            builder.ToTable("lab", "dblab");

            builder.HasKey(x => x.Id);

            builder.Property("Id").HasColumnName("id");
            builder.Property("LabCode").HasColumnName("lab");
            builder.Property("Andar").HasColumnName("andar");
            builder.Property("Description").HasColumnName("description");
            builder.Property("IsActive").HasColumnName("is_active");
        }
    }
}
