using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using VendasWebAplication.Models;

namespace VendasWebAplication.Data
{
    public class VendasWebAplicationContext : DbContext
    {
        public VendasWebAplicationContext (DbContextOptions<VendasWebAplicationContext> options) : base(options)
        {
        }

        public DbSet<Department> Department { get; set; } 
        public DbSet<Seller> Seller { get; set; }
        public DbSet<SalesRecord> SalesRecord { get; set; }
        
    }
}
