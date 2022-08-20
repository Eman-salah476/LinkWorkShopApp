using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WorkShopApp.Models;

namespace WorkShopApp.Dtos
{
    public class ProductModel
    {
        public List<Product> Products { get; set; }
        public int CurrentPageIndex { get; set; }
        public int PageCount { get; set; }
        public int? CategoryId { get; set; }
    }
}
