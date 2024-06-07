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

        // Passo 1: Retorna todos os vendedores do banco de dados.
        public List<Seller> FindAll()
        {
            return _context.Seller.ToList();
        }
        
        // Passo 2: Insere um novo vendedor no banco de dados.
        public void Insert(Seller obj)
        {
            
            _context.Add(obj);
            _context.SaveChanges();
        }

        // Passo 3: Encontra um vendedor pelo seu ID no banco de dados.
        public Seller FindById(int id) 
        {
            return _context.Seller.FirstOrDefault(obj => obj.Id == id);
        }

        // Passo 4: Remove um vendedor do banco de dados com base no seu ID.
        public void Remove(int id)
        {
            var obj = _context.Seller.Find(id);
            if (obj != null)
            {
                _context.Seller.Remove(obj);
                _context.SaveChanges();
            }
        }

    }
}
