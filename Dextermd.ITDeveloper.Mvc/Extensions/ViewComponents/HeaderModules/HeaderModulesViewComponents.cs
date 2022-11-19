using Dextermd.ITDeveloper.Mvc.Extensions.ViewComponents.Helpers;
using Microsoft.AspNetCore.Mvc;

namespace Dextermd.ITDeveloper.Mvc.Extensions.ViewComponents.HeaderModules
{
    [ViewComponent(Name = "HeaderModules")]
    public class HeaderModulesViewComponents : ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync(string title, string subtitle)
        {
            var module = new Module()
            {
                Title = title,
                Subtitle = subtitle
            };

            return View(module);
        }
    }
}
