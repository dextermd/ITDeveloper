using Dextermd.ITDeveloper.Data.ORM;
using Dextermd.ITDeveloper.Mvc.Extensions.ViewComponents.Helpers;
using Microsoft.AspNetCore.Mvc;

namespace Dextermd.ITDeveloper.Mvc.Extensions.ViewComponents.PacientStatus
{
    [ViewComponent(Name = "SeriousStatus")]

    public class SeriousStatusViewComponents : ViewComponent
    {
        private readonly ITDeveloperDbContext _context;
        public SeriousStatusViewComponents(ITDeveloperDbContext context)
        {
            _context = context;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var totalAllReg = Util.TotalAllReg(_context);
            decimal totalNumRegStatus = Util.GetNumRegStatus(_context, "Serious");

            decimal progress = totalNumRegStatus * 100 / totalAllReg;
            var percentTotal = progress.ToString("F1");

            var model = new PatientStatusCounter()
            {
                Title = "Serious Status",
                Partial = (int)totalNumRegStatus,
                Percent = percentTotal,
                ClassContainer = "panel panel-danger tile panelClose panelRefresh",
                IconLg = "l-basic-life-buoy",
                IconSm = "fa fa-arrow-circle-o-down s20 mr5 pull-left",
                Progress = progress
            };

            return View(model);
        }
    }
}
