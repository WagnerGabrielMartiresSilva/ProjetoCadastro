using Microsoft.AspNetCore.Mvc;
using VendasWebAplication.Models;
using VendasWebAplication.Models.ViewModels;
using VendasWebAplication.Services;

namespace VendasWebAplication.Controllers
{
    public class SellersController : Controller
    {
        private readonly SellerService _sellerService;
        private readonly DepartmentService _departmentService;

        public SellersController(SellerService sellerService, DepartmentService departmentService)
        {
            _sellerService = sellerService;
            _departmentService = departmentService;
        }

        public IActionResult Index()
        {
            var list = _sellerService.FindAll();

            //encaminhando os dados "list" para view
            return View(list);
        }

        public IActionResult Create()
        {

            var departments = _departmentService.FindAll();
            var viewModel = new SellerFormViewModel { Departments = departments };
            //encaminhando os dados 
            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Seller seller)
        {
            _sellerService.Insert(seller);
            return RedirectToAction(nameof(Index));
        }


    }
}