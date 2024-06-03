using Microsoft.AspNetCore.Mvc;

namespace VendasWebAplication.Controllers
{
    public class SellersController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
