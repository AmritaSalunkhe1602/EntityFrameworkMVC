using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ChkCodeFirstEx.Models
{
    public class ProdVM
    {
        public Int64 ProductId { get; set; }
        public string ProductName { get; set; }
        public int Count { get; set; }
    }
}