using Microsoft.AspNetCore.Mvc;

namespace PasteBin.Controllers
{
    public class ViewController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
