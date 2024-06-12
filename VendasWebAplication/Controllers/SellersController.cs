using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using VendasWebAplication.Models;
using VendasWebAplication.Models.ViewModels;
using VendasWebAplication.Services;
using VendasWebAplication.Services.Exceptions;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace VendasWebAplication.Controllers
{
    public class SellersController : Controller
    {
        private readonly SellerService _sellerService;
        private readonly DepartmentService _departmentService;
       

        // Construtor da classe SellersController
        public SellersController(SellerService sellerService, DepartmentService departmentService)
        {
            _sellerService = sellerService;
            _departmentService = departmentService;
        }
        public IActionResult Index()
        {
<<<<<<< HEAD
            var list =  _sellerService.FindAll();
=======
            var list = _sellerService.FindAll();
>>>>>>> 6b3b08681ed6b267ab6bcf3f9ea9518e2a94d12d
            return View(list);
        }
        public IActionResult Create()
        {
<<<<<<< HEAD
            var departments =  _departmentService.FindAll();
=======
            var departments = _departmentService.FindAll();
>>>>>>> 6b3b08681ed6b267ab6bcf3f9ea9518e2a94d12d
            var viewModel = new SellerFormViewModel { Departments = departments };
            return View(viewModel);
        }

<<<<<<< HEAD
        


=======
>>>>>>> 6b3b08681ed6b267ab6bcf3f9ea9518e2a94d12d
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Seller seller)
        {
           
<<<<<<< HEAD
             _sellerService.Insert(seller);
=======
            _sellerService.Insert(seller);
>>>>>>> 6b3b08681ed6b267ab6bcf3f9ea9518e2a94d12d
            return RedirectToAction(nameof(Index));
        }
       


        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return RedirectToAction(nameof(Error), new {message = "Id not provided"});
            }

<<<<<<< HEAD
            var obj =  _sellerService.FindById(id.Value);
=======
            var obj = _sellerService.FindById(id.Value);
>>>>>>> 6b3b08681ed6b267ab6bcf3f9ea9518e2a94d12d
            if (obj == null)
            {
                return RedirectToAction(nameof(Error), new { message = "Id Não Encontrado" });
            }

            return View(obj);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(int id)
        {
<<<<<<< HEAD

=======
>>>>>>> 6b3b08681ed6b267ab6bcf3f9ea9518e2a94d12d
            _sellerService.Remove(id);
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return RedirectToAction(nameof(Error), new { message = "Id not provided" });
            }

<<<<<<< HEAD
            var obj =  _sellerService.FindById(id.Value);
=======
            var obj = _sellerService.FindById(id.Value);
>>>>>>> 6b3b08681ed6b267ab6bcf3f9ea9518e2a94d12d
            if (obj == null)
            {
                return RedirectToAction(nameof(Error), new { message = "Id Não Encontrado" });
            }

            return View(obj);
        }

        public IActionResult Edit(int? id)
        {

            if (id == null)
            {

                return RedirectToAction(nameof(Error), new { message = "Id not provided" });
            }

<<<<<<< HEAD
            var obj =  _sellerService.FindById(id.Value);
=======
            var obj = _sellerService.FindById(id.Value);
>>>>>>> 6b3b08681ed6b267ab6bcf3f9ea9518e2a94d12d
            if(obj == null)
            {
                return RedirectToAction(nameof(Error), new { message = "Id Não Encontrado" });
            }

<<<<<<< HEAD
            List<Department> departments =  _departmentService.FindAll();
=======
            List<Department> departments = _departmentService.FindAll();
>>>>>>> 6b3b08681ed6b267ab6bcf3f9ea9518e2a94d12d
            // aqui o obj e o departments faz com que a lista já venha carregada
            SellerFormViewModel viewModel = new SellerFormViewModel { Seller = obj, Departments = departments };
            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, Seller seller)
        {
<<<<<<< HEAD
            

            if (id != seller.Id)
            {
                return RedirectToAction(nameof(Error), new { message = "Id not mismatch" });
=======
           
            if (id != seller.Id)
            {
                return BadRequest();
>>>>>>> 6b3b08681ed6b267ab6bcf3f9ea9518e2a94d12d
            }
            try
            {
                _sellerService.Update(seller);
                return RedirectToAction(nameof(Index));
            }
            catch (NotFoundException e)
            {
                return RedirectToAction(nameof(Error), new { message = e.Message });
            }
            catch (DbConcurrencyException e)
            {
                return RedirectToAction(nameof(Error), new { message = e.Message });
            }
        }

        public IActionResult Error(string message)
        {
            var viewModel = new ErrorViewModel
            {
                Message = message,
                //Comando para pegar o Id interno da requisição
                RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier
            };
            return View(viewModel);
             
        }

    }
}



