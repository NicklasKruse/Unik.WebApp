using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unik.Domain.Entities;

namespace SqlServerContext.Configuration
{
    public class InvitationConfiguration : IEntityTypeConfiguration<Invitation>
    {
        public void Configure(EntityTypeBuilder<Invitation> builder)
        {
            builder.ToTable("Invitation", "invitation");
            builder.HasKey(e => e.Id); // Primary Key egentlig ikke nødvendig da EF Core antager at en property som hedder Id eller <type>Id er PK
        }
    }

}

