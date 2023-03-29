using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace ChkCodeFirstEx.Models
{
    public class CompanyContext:DbContext
    {
        public CompanyContext() : base("scon") { }
        public DbSet<Product>Products { get; set; }
        public DbSet<Color> Colors { get; set; }
        public DbSet<ProductColor>ProductColors { get; set; }
    }
}