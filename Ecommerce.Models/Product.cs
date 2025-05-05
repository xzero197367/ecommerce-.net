using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Models
{
    public class Product
    {
        public int ProductId { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public int UnitsInStock { get; set; }
        public string ImagePath { get; set; }
        public int CategoryID { get; set; }
        public Category Category { get; set; }
    }
}
