using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace CustomerApplication.Models
{
    public class ProductsContext : DbContext
    {
        public DbSet<Products> ProductList { get; set; }
        public DbSet<ProductDetails> ProductDetailsList { get; set; }
    }
}