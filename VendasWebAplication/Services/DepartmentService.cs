using VendasWebAplication.Data;
using VendasWebAplication.Models;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace VendasWebAplication.Services
{
    public class DepartmentService
    {
        private readonly VendasWebAplicationContext _context;

        public DepartmentService(VendasWebAplicationContext context)
        {
            _context = context;
        }

        public  List<Department> FindAll()
        {
            return  _context.Department.OrderBy(x => x.Name).ToList();
        }
    }
}
