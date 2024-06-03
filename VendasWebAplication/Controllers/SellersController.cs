using Microsoft.AspNetCore.Mvc;
using VendasWebAplication.Services;

namespace VendasWebAplication.Controllers
{
    public class SellersController : Controller
    {
        private readonly SellerService _sellerService;

        public SellersController(SellerService sellerService)
        {
            _sellerService = sellerService;
        }

        public IActionResult Index()
        {
            var list = _sellerService.FindAll();
            
            //encaminhando os dados "list" para view
            return View(list);
        }
    }
}
