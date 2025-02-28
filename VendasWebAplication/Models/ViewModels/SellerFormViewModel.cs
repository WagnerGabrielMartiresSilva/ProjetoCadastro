﻿using System.Collections.Generic;
using VendasWebAplication.Models;

namespace VendasWebAplication.Models.ViewModels
{
    public class SellerFormViewModel
    {
        public Seller Seller { get; set; }
        public ICollection<Department> Departments { get; set; }
    }
}
