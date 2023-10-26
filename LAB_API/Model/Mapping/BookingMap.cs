using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LAB_API.Model.Mapping
{
    public class BookingMap : IEntityTypeConfiguration<Booking>
    {
        public void Configure(EntityTypeBuilder<Booking> builder)
        {
            builder.ToTable("booking", "dblab");

            builder.HasKey(x => x.Id);

            builder.Property("Id")
                .HasColumnName("id");

            builder.Property("UserId")
                .HasColumnName("user_id");

            builder.Property("LabId")
                .HasColumnName("lab_id");

            builder.Property("Date")
                .HasColumnName("date");

            builder.HasOne(x => x.User);
            builder.HasOne(x => x.Lab);
        }
    }
}
