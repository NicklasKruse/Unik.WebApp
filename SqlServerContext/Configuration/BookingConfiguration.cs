using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Unik.Domain.Entities;

namespace SqlServerContext.Configuration
{
    public class BookingConfiguration : IEntityTypeConfiguration<Booking>
    {
        public void Configure(EntityTypeBuilder<Booking> builder)
        {
            builder.ToTable("Booking", "booking");
            builder.HasKey(e => e.Id); // Primary Key egentlig ikke nødvendig da EF Core antager at en property som hedder Id eller <type>Id er PK
        }
    }
}
