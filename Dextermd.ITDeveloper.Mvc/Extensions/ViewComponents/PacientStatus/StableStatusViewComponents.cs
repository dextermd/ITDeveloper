using Dextermd.ITDeveloper.Data.ORM;
using Dextermd.ITDeveloper.Mvc.Extensions.ViewComponents.Helpers;
using Microsoft.AspNetCore.Mvc;

namespace Dextermd.ITDeveloper.Mvc.Extensions.ViewComponents.PacientStatus
{
    [ViewComponent(Name = "StableStatus")]
    public class StableStatusViewComponents : ViewComponent
    {
        private readonly ITDeveloperDbContext _context;
        public StableStatusViewComponents(ITDeveloperDbContext context)
        {
            _context = context;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var totalAllReg = Util.TotalAllReg(_context);
            decimal totalNumRegStatus = Util.GetNumRegStatus(_context, "Stable");

            decimal progress = totalNumRegStatus * 100 / totalAllReg;
            var percentTotal = progress.ToString("F1");

            var model = new PatientStatusCounter()
            {
                Title = "Stable Status",
                Partial = (int)totalNumRegStatus,
                Percent = percentTotal,
                ClassContainer = "panel panel-success tile panelClose panelRefresh",
                IconLg = "l-ecommerce-cart-content",
                IconSm = "fa fa-arrow-circle-o-up s20 mr5 pull-left",
                Progress = progress
            };

            return View(model);
        }
    }
}
