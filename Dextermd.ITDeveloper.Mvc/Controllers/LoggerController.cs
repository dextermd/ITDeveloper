using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Dextermd.ITDeveloper.Mvc.Controllers
{
    public class LoggerController : Controller
    {
        private readonly ILogger<LoggerController> logger;

        public LoggerController(ILogger<LoggerController> logger)
        {
           this.logger = logger;
        }

        public IActionResult Index()
        {
            var msgLogger = "Testing Logger Display!";

            logger.Log(LogLevel.Critical, msgLogger);
            logger.Log(LogLevel.Warning, msgLogger);
            logger.Log(LogLevel.Trace, msgLogger);
            logger.LogError(msgLogger);

            try
            {
                throw new Exception("An exception was raised for audit testing!");
            }
            catch (Exception e)
            {
                logger.LogError(e.Message);
                throw;
            }

            ViewData["msgLogger"] = msgLogger;

            return View();
        }
    }
}
