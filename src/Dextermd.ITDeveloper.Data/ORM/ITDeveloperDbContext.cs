using Dextermd.ITDeveloper.Domain.Entities;
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
        public ITDeveloperDbContext (DbContextOptions<ITDeveloperDbContext> options)
            :base(options)
        {}

        public DbSet<Mural> Mural { get; set; }
    }
}
