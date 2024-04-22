using Microsoft.AspNetCore.Mvc;

namespace SignalR.WebUI.Controllers
{
    public class ProgressBarsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
