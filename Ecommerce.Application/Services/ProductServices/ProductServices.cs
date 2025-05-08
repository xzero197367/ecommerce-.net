using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Ecommerce.Application.Contracts;
using Ecommerce.DTOs;
using Ecommerce.Models;
using Mapster;

namespace Ecommerce.Application.Services.ProductServices
{
   public class ProductServices : IProductServices

        
    {
        private readonly IProductRepo _productRepo;

        public ProductServices(IProductRepo productRepo)
        {
            _productRepo = productRepo;
        }

        public ProductDto CreateProduct(Product pro)
        {
            var createproduct = _productRepo.Create(pro);
            _productRepo.SaveChanges();
            return createproduct.Adapt<ProductDto>();
        }

        public ProductDto UpdateProduct(Product product)
        {
            var existingProduct = _productRepo.GetById(product.ProductId) ?? throw new Exception("Product not found");
            existingProduct.Name = product.Name;
            existingProduct.Description = product.Description;
            existingProduct.Price = product.Price;
            existingProduct.UnitsInStock = product.UnitsInStock;
            existingProduct.CategoryID = product.CategoryID;
            existingProduct.ImagePath = product.ImagePath;

            var updatedProduct = _productRepo.Update(existingProduct);
            _productRepo.SaveChanges();
            return updatedProduct.Adapt<ProductDto>();
        }

        public void DeleteProduct(int id)
        {
            var product = _productRepo.GetById(id) ?? throw new Exception("Product not found");
            _productRepo.Delete(product);
            _productRepo.SaveChanges();
        }

        public ProductDto GetProductById(int id)
        {
            var product = _productRepo.GetById(id) ?? throw new Exception("Product not found");
            return product.Adapt<ProductDto>();
        }

        public List<ProductDto> GetAllProducts()
        {
            return _productRepo.GetAll()
                .ToList()
                .Adapt<List<ProductDto>>();
        }

        public List<ProductDto> SearchProducts(string keyword)
        {
            return _productRepo.Search(keyword)
                .ToList()
                .Adapt<List<ProductDto>>();
        }

        public List<ProductDto> GetProductsByCategory(int categoryId)
        {
            return _productRepo.GetByCategory(categoryId)
                .ToList()
                .Adapt<List<ProductDto>>();
        }





        //public partial class ProductListForm : Form
        //{
        //    private readonly IProductService _productService;

        //   public ProductListForm()
        //{
        //    InitializeComponent();

        //    var container = AutofacConfig.Inject();
        //    _productService = container.Resolve<IProductService>();
        //}

        //private async void ProductListForm_Load(object sender, EventArgs e)
        //{
        //    var products = await _productService.GetAllProductsAsync();
        //    dgvProducts.DataSource = products;
        //}
        // }


        //public async Task<List<ProductDto>> GetAllProductsAsync()
        //{
        //    var products = await _productRepo.GetAll();


        //    //return products.Select(p => new ProductDto
        //    //{
        //    //    ProductID = p.ProductId,
        //    //    Name = p.Name,
        //    //    Price = p.Price,
        //    //    UnitsInStock = p.UnitsInStock,
        //    //    CategoryName = p.Category != null ? p.Category.Name : "DONT"
        //    //}).ToList();

        //    return products.Adapt<List<ProductDto>>(); // Using Mapster for mapping
        //}



        //public async Task<ProductDetailDto?> GetProductByIdAsync(int id)
        //{
        //    var product = await _productRepo.GetAsync(p => p.ProductId == id);

        //    if (product == null)
        //        return null;

        //    //return new ProductDetailDto
        //    //{
        //    //    ProductID = product.ProductId,
        //    //    Name = product.Name,
        //    //   // Description = product.
        //    //    Price = product.Price,
        //    //    UnitsInStock = product.UnitsInStock,
        //    //    ImagePath = product.ImagePath,
        //    //    CategoryName = product.Category?.Name ?? "Unknown"
        //    //};
        //    return product.Adapt<ProductDetailDto>(); // Using Mapster for mapping
        //}

    }
}
