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
    public class PacientMap : IEntityTypeConfiguration<Pacient>
    {
        public void Configure(EntityTypeBuilder<Pacient> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Name).IsRequired().HasColumnType("varchar(80)")
                .HasColumnName("Name");

            builder.Property(x => x.Email).HasColumnName("Email")
                .HasColumnType("varchar(150)");

            builder.Property(x => x.Cpf)
                .HasMaxLength(11).IsFixedLength(true)
                .HasColumnName("Cpf").HasColumnType("varchar(11)");

            builder.Property(x => x.Rg).HasMaxLength(15).HasColumnName("Rg")
                .HasColumnType("varchar(15)");

            builder.Property(x => x.RgOrgan).HasColumnName("RgOrgan")
                .HasColumnType("varchar(10)");

            builder.HasOne(ps => ps.PacientStatus)
                .WithMany(pc => pc.Pacient)
                .HasForeignKey(p => p.PacientStatusId)
                .HasPrincipalKey(p => p.Id);

            builder.ToTable("Pacient");
        }
    }
}
