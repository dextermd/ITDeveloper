using Dextermd.ITDeveloper.Data.ORM;
using Microsoft.EntityFrameworkCore;

namespace Dextermd.ITDeveloper.Mvc.Extensions.ViewComponents.Helpers
{
    public static class Util
    {
        public static int TotalAllReg(ITDeveloperDbContext context)
        {
            return (from pac in context.Pacient.AsNoTracking() select pac).Count();
        }

        public static decimal GetNumRegStatus(ITDeveloperDbContext context, string status)
        {
            return context.Pacient
                .Include( x => x.PacientStatus)
                .AsNoTracking()
                .Count( x => x.PacientStatus.Description.Contains(status));
        }
    }
}
