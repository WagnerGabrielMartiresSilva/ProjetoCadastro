using VendasWebAplication.Controllers;
using VendasWebAplication.Data;
using VendasWebAplication.Models;

namespace VendasWebAplication.Services
{
    public class SellerService
    {
        private readonly VendasWebAplicationContext _context;

        public SellerService(VendasWebAplicationContext context)
        {
            _context = context;
        }

        //Retorna todos os vendedores
        public List<Seller> FindAll()
        {
            return _context.Seller.ToList();
        }

        public void Insert(Seller obj)
        {
            obj.Department = _context.Department.First();
            _context.Add(obj);
            _context.SaveChanges();
        }


    }
}
