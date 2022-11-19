using Dextermd.ITDeveloper.Data.ORM;
using Dextermd.ITDeveloper.Mvc.Extensions.ViewComponents.Helpers;
using Microsoft.AspNetCore.Mvc;

namespace Dextermd.ITDeveloper.Mvc.Extensions.ViewComponents.PacientStatus
{
    public class ObservationStatusViewComponents : ViewComponent
    {
        private readonly ITDeveloperDbContext _context;
        public ObservationStatusViewComponents(ITDeveloperDbContext context)
        {
            _context = context;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var totalAllReg = Util.TotalAllReg(_context);
            decimal totalNumRegStatus = Util.GetNumRegStatus(_context, "Observation");

            decimal progress = totalNumRegStatus * 100 / totalAllReg;
            var percentTotal = progress.ToString("F1");

            var model = new PatientStatusCounter() 
            {
                Title = "Observation Pacients",
                Partial = (int)totalNumRegStatus,
                Percent = percentTotal,
                ClassContainer = "panel panel-default tile panelClose panelRefresh",
                IconLg = "l-banknote",
                IconSm = "fa fa-arrow-circle-o-down s20 mr5 pull-left",
                Progress= progress
            };

            return View(model);
        }
    }
}
