using Demo.Models.Demo;
using Microsoft.AspNetCore.Mvc;

namespace Demo.Controllers
{
    public class DemoController : Controller
    {
        public IActionResult Index()
        {
            var model = new IndexModel();
            return View(model);
        }
    }
}
