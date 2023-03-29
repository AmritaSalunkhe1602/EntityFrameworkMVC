using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ChkCodeFirstEx.Models
{
    public class ProductColor
    {
        public Int64 ProductColorId { get; set; }
        public Int64 ColorId { get; set; }
        public Int64 ProductId { get; set; }
        public virtual Product Product { get; set; }
        public virtual Color Color { get; set; }
    }
}