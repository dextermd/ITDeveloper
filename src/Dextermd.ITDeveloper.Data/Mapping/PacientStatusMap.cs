using Dextermd.ITDeveloper.Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dextermd.ITDeveloper.Data.Mapping
{
    public class PacientStatusMap : IEntityTypeConfiguration<PacientStatus>
    {
        public void Configure(EntityTypeBuilder<PacientStatus> builder)
        {
            builder.HasKey(pk => pk.Id);
            builder.Property(p => p.Description).HasColumnType("varchar(30)")
                .HasColumnName("Description");

            builder.HasMany(p => p.Pacient);

            builder.ToTable("PacientStatus");
        }
    }
}
