using LAB_API.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LAB_API.Mapping
{
    public class UserTypeMap : IEntityTypeConfiguration<UserType>
    {
        public void Configure(EntityTypeBuilder<UserType> builder)
        {
            builder.ToTable("user_type", "dblab");

            builder.HasKey(x => x.Id);

            builder.Property("Id").HasColumnName("id");
            builder.Property("Description").HasColumnName("description");
        }
    }
}
