using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ChkCodeFirstEx.Models
{
    public class Color
    {
        public Int64 ColorId { get; set; }
        public string ColorName { get; set; }
        public virtual List<ProductColor>ProductColors { get; set; }
    }
}