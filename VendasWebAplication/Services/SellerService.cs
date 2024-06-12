using VendasWebAplication.Data;
using VendasWebAplication.Services;
using VendasWebAplication.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
<<<<<<< HEAD
=======
using Microsoft.EntityFrameworkCore;
>>>>>>> 6b3b08681ed6b267ab6bcf3f9ea9518e2a94d12d
using VendasWebAplication.Services.Exceptions;

namespace VendasWebAplication.Services
{
    public class SellerService
    {
        private readonly VendasWebAplicationContext _context;

        public SellerService(VendasWebAplicationContext context)
        {
            _context = context;
        }

<<<<<<< HEAD
        public  List<Seller> FindAll()
        {

            return  _context.Seller.ToList();
=======
        public List<Seller> FindAll()
        {

            return _context.Seller.ToList();
>>>>>>> 6b3b08681ed6b267ab6bcf3f9ea9518e2a94d12d
        }

        public void Insert(Seller obj)
        {
            
            _context.Add(obj);
            _context.SaveChanges();
        }

        public Seller FindById(int id)
        {
<<<<<<< HEAD
            return  _context.Seller.Include(obj => obj.Department).FirstOrDefault(obj => obj.Id ==  id);
=======
            return _context.Seller.Include(obj => obj.Department).FirstOrDefault(obj => obj.Id ==  id);
>>>>>>> 6b3b08681ed6b267ab6bcf3f9ea9518e2a94d12d
        }

        public void Remove(int id)
        {
<<<<<<< HEAD
            var obj =  _context.Seller.Find(id);
            _context.Seller.Remove(obj);
           _context.SaveChanges();
=======
            var obj = _context.Seller.Find(id);
            _context.Seller.Remove(obj);
            _context.SaveChanges();
>>>>>>> 6b3b08681ed6b267ab6bcf3f9ea9518e2a94d12d
        }

        public void Update(Seller obj)
        {
            //Estou testando no banco de dados se algum vendedor x cujo id seja igual o id do meu objeto
<<<<<<< HEAD

            if (!_context.Seller.Any(x => x.Id == obj.Id))
=======
            if(!_context.Seller.Any(x => x.Id == obj.Id))
>>>>>>> 6b3b08681ed6b267ab6bcf3f9ea9518e2a94d12d
            {
                throw new NotFoundException("Id not found Exception");
            }
            try
            {
                _context.Update(obj);
                _context.SaveChanges();
            }
            catch(DbConcurrencyException e)
            {
                throw new DbConcurrencyException(e.Message);
            }
            
        }
    }



}

