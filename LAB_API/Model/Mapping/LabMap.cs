using LAB_API.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LAB_API.Model.Mapping
{
    /// <summary>
    /// 
    /// </summary>
    public class LabMap : IEntityTypeConfiguration<Lab>
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="builder"></param>
        public void Configure(EntityTypeBuilder<Lab> builder)
        {
            builder.ToTable("lab", "dblab");

            builder.HasKey(x => x.Id);

            builder.Property("Id")
                .HasColumnName("id");

            builder.Property("LabCode")
                .HasColumnName("lab");

            builder.Property("Andar")
                .HasColumnName("andar");

            builder.Property("Description")
                .HasColumnName("description");

            builder.Property("IsActive")
                .HasColumnName("is_active");
        }
    }
}
