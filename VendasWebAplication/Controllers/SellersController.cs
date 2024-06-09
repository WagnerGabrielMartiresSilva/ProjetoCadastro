using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using VendasWebAplication.Models;
using VendasWebAplication.Models.ViewModels;
using VendasWebAplication.Services;
using VendasWebAplication.Services.Exceptions;

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

        // Ação para exibir a lista de vendedores
        public IActionResult Index()
        {
            // Obtém a lista de todos os vendedores
            var list = _sellerService.FindAll();

            // Encaminha os dados "list" para a view Index
            return View(list);
        }

        // Ação para exibir o formulário de criação de um novo vendedor
        public IActionResult Create()
        {
            // Obtém a lista de todos os departamentos
            var departments = _departmentService.FindAll();

            // Cria uma instância de SellerFormViewModel contendo os departamentos
            var viewModel = new SellerFormViewModel { Departments = departments };

            // Encaminha os dados para a view Create
            return View(viewModel);
        }

        // Ação para processar o formulário de criação de um novo vendedor
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Seller seller)
        {
            if (!ModelState.IsValid)
            {
                var departments = _departmentService.FindAll();
                var viewModel = new SellerFormViewModel { Seller = seller, Departments = departments };
                return View(viewModel);
            }
            // Insere o novo vendedor no banco de dados
            _sellerService.Insert(seller);

            // Redireciona para a página de listagem de vendedores (Index)
            return RedirectToAction(nameof(Index));
        }

        // Ação para exibir a página de confirmação de exclusão de um vendedor
        public IActionResult Delete(int? id)
        {
            // Verifica se o ID do vendedor foi fornecido
            if (id == null)
            {
                return RedirectToAction(nameof(Error), new {message = "Id not provided"} );
            }

            // Busca o vendedor pelo ID
            var obj = _sellerService.FindById(id.Value);

            // Verifica se o vendedor foi encontrado
            if (obj == null)
            {
                return RedirectToAction(nameof(Error), new { message = "Id not found" });
            }

            // Encaminha os dados do vendedor para a view Delete
            return View(obj);
        }

        // Ação para processar a exclusão de um vendedor
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            // Remove o vendedor do banco de dados
            _sellerService.Remove(id);

            // Redireciona para a página de listagem de vendedores (Index)
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Details(int? id)
        {


            if (id == null)
            {
                return RedirectToAction(nameof(Error), new { message = "Id not provided" });
            }


            var obj = _sellerService.FindById(id.Value);
            if (obj == null)
            {
                return RedirectToAction(nameof(Error), new { message = "Id not found" });
            }

            return View(obj);

        }

        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return RedirectToAction(nameof(Error), new { message = "Id not provided" });
            }

            var obj = _sellerService.FindById(id.Value);
            if (obj == null)
            {
                return RedirectToAction(nameof(Error), new { message = "Id not found" });
            }

            List<Department> departments = _departmentService.FindAll();
            SellerFormViewModel viewModel = new SellerFormViewModel { Seller = obj, Departments = departments };
            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int? id, Seller seller)
        {

            if (!ModelState.IsValid)
            {
                var departments = _departmentService.FindAll();
                var viewModel = new SellerFormViewModel { Seller = seller, Departments = departments };
                return View(viewModel);
            }
            if (id != seller.Id)
            {
                return RedirectToAction(nameof(Error), new { message = "Id mismatch" });
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
            var ViewModel = new ErrorViewModel
            {
                Message = message,
                //Serve para pegar o Id interno da Requisição
                RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier
            };
            return View(ViewModel);
        }
    }
}


