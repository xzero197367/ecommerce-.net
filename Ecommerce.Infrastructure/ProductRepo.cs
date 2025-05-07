using Ecommerce.Application.Contracts;
using Ecommerce.Context;
using Ecommerce.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Infrastructure
{
    public class ProductRepo : GenericRepo<Product>, IProductRepo
    {
        private readonly ContextDB _context;

        public ProductRepo(ContextDB context) : base(context)
        {
            _context = context;
        }

        public IQueryable<Product> GetProductByCategory(int categoryId)
        {
            return _context.products.Where(p => p.CategoryID == categoryId);

        }

        //name, description, price, stock, category
        public IQueryable<Product> SearchProduct(string Term)
        {
            return
           _context.products
           .Include(p => p.Category)
           .Where(p => p.Name.Contains(Term)
           || p.Category.Description.Contains(Term)
           || p.Price.ToString().Contains(Term)
           || p.UnitsInStock.ToString().Contains(Term)
           || p.Category.Name.Contains(Term));
        }
    }
}
