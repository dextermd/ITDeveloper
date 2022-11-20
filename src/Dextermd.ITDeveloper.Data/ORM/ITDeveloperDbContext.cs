using Dextermd.ITDeveloper.Data.Mapping;
using Dextermd.ITDeveloper.Domain.Entities;
using Dextermd.ITDeveloper.Domain.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dextermd.ITDeveloper.Data.ORM
{


    public class ITDeveloperDbContext : DbContext
    {

        public ITDeveloperDbContext(DbContextOptions<ITDeveloperDbContext> options) : base(options)
        {
        }

        public DbSet<Mural> Mural { get; set; }

        public DbSet<Pacient> Pacient { get; set; }

        public DbSet<PacientStatus> PacientStatus { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new PacientStatusMap());
            modelBuilder.ApplyConfiguration(new PacientMap());

/*            modelBuilder.ApplyConfigurationsFromAssembly(typeof(ITDeveloperDbContext).Assembly);*/


/*            foreach (var property in modelBuilder
               .Model
               .GetEntityTypes()
               .SelectMany(
                  e => e.GetProperties()
                     .Where(p => p.ClrType == typeof(string))))
            {
                property.SetColumnType("varchar(100)");
            }

            

            foreach (var relationship in modelBuilder.Model.GetEntityTypes().SelectMany(e => e.GetForeignKeys()))
            {
                relationship.DeleteBehavior = DeleteBehavior.ClientSetNull;
            }*/

            base.OnModelCreating(modelBuilder);
        }
    }
}
