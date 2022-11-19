using Dextermd.ITDeveloper.Data.ORM;
using Dextermd.ITDeveloper.Mvc.Extensions.ViewComponents.Helpers;
using Microsoft.AspNetCore.Mvc;

namespace Dextermd.ITDeveloper.Mvc.Extensions.ViewComponents.PacientStatus
{
    [ViewComponent(Name = "CriticalStatus")]
    public class CriticalStatusViewComponents : ViewComponent
    {
        private readonly ITDeveloperDbContext _context;
        public CriticalStatusViewComponents(ITDeveloperDbContext context)
        {
            _context = context;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var totalAllReg = Util.TotalAllReg(_context);
            decimal totalNumRegStatus = Util.GetNumRegStatus(_context, "Critical");

            decimal progress = totalNumRegStatus * 100 / totalAllReg;
            var percentTotal = progress.ToString("F1");

            var model = new PatientStatusCounter()
            {
                Title = "Critical Status",
                Partial = (int)totalNumRegStatus,
                Percent = percentTotal,
                ClassContainer = "panel panel-info tile panelClose panelRefresh",
                IconLg = "l-basic-geolocalize-05",
                IconSm = "fa fa-arrow-circle-o-up s20 mr5 pull-left",
                Progress = progress
            };

            return View(model);
        }
    }
}
