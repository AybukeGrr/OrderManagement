using Microsoft.AspNetCore.Mvc;

namespace WebUI.Controllers
{
    public class CategoryController1 : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
