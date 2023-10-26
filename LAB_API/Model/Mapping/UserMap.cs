using LAB_API.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LAB_API.Model.Mapping
{
    public class UserMap : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.ToTable(name: "user", schema: "dblab");
            builder.HasKey(x => x.Id);

            builder.Property("Id").HasColumnName("id");
            builder.Property("Name").HasColumnName("name");
            builder.Property("Email").HasColumnName("email");
            builder.Property("UserTypeId").HasColumnName("user_type_id");
            builder.Property("Password").HasColumnName("password");
            builder.Property("IsActive").HasColumnName("is_active");
            builder.Property("CpfCnpj").HasColumnName("cpf_cnpj");
            builder.Property("Phone").HasColumnName("phone");

            builder.HasOne(x => x.UserType);

        }
    }
}
