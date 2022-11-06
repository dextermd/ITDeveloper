using Microsoft.EntityFrameworkCore.Design;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dextermd.ITDeveloper.Data.ORM
{
    internal class ITDeveloperDbContextFactory : IDesignTimeDbContextFactory<ITDeveloperDbContext>
    {
        public ITDeveloperDbContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<ITDeveloperDbContext>();
            optionsBuilder.UseSqlServer("Server=.;Database=CursANCore6Database;Trusted_Connection=true;MultipleActiveResultSets=true;");

            return new ITDeveloperDbContext(optionsBuilder.Options);
        }
  
    
    }
}
