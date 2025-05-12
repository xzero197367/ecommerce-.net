using Autofac;
using Ecommerce.AdminFront.Classes.AutoFac;
using Ecommerce.AdminFront.Pages.Categories;
using Ecommerce.Application.Services.ProductServices;
using Ecommerce.DTOs;
using System;


namespace Ecommerce.AdminFront.Pages.Products
{
    public class ProductHandler
    {
        private IProductServices productServices;
        private ProductHandler()
        {
            var container = AutoFac.Inject();
            productServices = container.Resolve<IProductServices>();
        }

        private static ProductHandler? _instance;

        public static ProductHandler GetInstance()
        {
            if (_instance == null)
            {
                _instance = new ProductHandler();
            }
            return _instance;
        }


        public async Task<(bool status, string message)> DeleteProduct(int id)
        {
            try
            {
                var res = await productServices.DeleteProductAsync(id);
                return res;
            }
            catch (Exception ex)
            {
                return (false, "something went wrong");
            }
        }

        public async Task<(bool status, string message)> onUpdateProduct(int id, ProductCreateDto dto)
        {
            var res = await productServices.UpdateProductAsync(id, dto);

            if (res == null)
            {
                return (false, "something went wrong");
            }
            return (true, "Product updated successfully");
        }

        public async Task<(bool status, string message)> CreateProduct(ProductCreateDto dto)
        {
            try
            {
                await productServices.CreateProductAsync(dto);
                return (true, "Product created successfully");
            }
            catch (Exception ex)
            {
                return (false, "something went wrong");
            }
        }

        public async Task<List<ProductDto>> GetProducts()
        {
            return await productServices.GetAllProducts();
        }


    }
}
