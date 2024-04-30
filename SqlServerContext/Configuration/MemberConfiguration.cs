using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Unik.Domain.Entities;

namespace SqlServerContext.Configuration
{
    public class MemberConfiguration : IEntityTypeConfiguration<Member>
    {
        public void Configure(EntityTypeBuilder<Member> builder)
        {
            builder.ToTable("Member", "member");
            builder.HasKey(e => e.Id); // Primary Key egentlig ikke nødvendig da EF Core antager at en property som hedder Id eller <type>Id er PK
        }
    }
}
