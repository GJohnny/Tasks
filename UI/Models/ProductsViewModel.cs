using DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UI.Models
{
    public class ProductsViewModel
    {
        public IEnumerable<Product> Products { get; set; }
        public int Count { get; set; }
    }
}
