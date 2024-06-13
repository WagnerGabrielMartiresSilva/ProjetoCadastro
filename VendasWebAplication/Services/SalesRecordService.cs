using VendasWebAplication.Data;
using VendasWebAplication.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace VendasWebAplication.Services
{
    public class SalesRecordService
    {
        private readonly VendasWebAplicationContext _context;

        public SalesRecordService(VendasWebAplicationContext context)
        {
            _context = context;
        }

        public List<SalesRecord> FindByDate(DateTime? minDate, DateTime? maxDate)
        {
            var result = from obj in _context.SalesRecord select obj;

            if (minDate.HasValue)
            {
                result = result.Where(x => x.Date >= minDate.Value);
            }

            if (maxDate.HasValue)
            {
                result = result.Where(x => x.Date <= maxDate.Value); ;
            }

            // Incluindo as propriedades de navegação Seller e Seller.Department
            return result
                .Include(x => x.Seller)
                .Include(x => x.Seller.Department)
                .OrderByDescending(x => x.Date)
                .ToList();
        }
        public List<IGrouping<Department, SalesRecord>> FindByDateGrouping(DateTime? minDate, DateTime? maxDate)
        {
            var query = _context.SalesRecord
                .Include(x => x.Seller)
                .Include(x => x.Seller.Department)
                .AsQueryable(); // Começa com IQueryable para construir a consulta dinamicamente

            if (minDate.HasValue)
            {
                query = query.Where(x => x.Date >= minDate.Value);
            }

            if (maxDate.HasValue)
            {
                query = query.Where(x => x.Date <= maxDate.Value);
            }

            // Realiza a ordenação antes de trazer os dados para a memória
            var result = query
                .OrderByDescending(x => x.Date)
                .ToList(); // Trás os dados para a memória

            // Agora faz o agrupamento em memória
            var groupedResult = result.GroupBy(x => x.Seller.Department).ToList();

            return groupedResult;
        }
    }
}
