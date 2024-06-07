﻿using VendasWebAplication.Data;
using VendasWebAplication.Models;

namespace VendasWebAplication.Services
{
    public class DepartmentService
    {
        private readonly VendasWebAplicationContext _context;

        public DepartmentService(VendasWebAplicationContext context)
        {
            _context = context;
        }

        public List<Department> FindAll()
        {
            return _context.Department.OrderBy(d => d.Name).ToList();
        }
    }
}
