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

        public IProductServices ProductService => productServices;


        public async Task<(bool status, string message)> DeleteProduct(int id)
        {
            try
            {
                var res = await productServices.DeleteAsync(id);
                return (res, res ? "Category deleted successfully" : "something went wrong");
            }
            catch (Exception ex)
            {
                return (false, "something went wrong");
            }
        }

        public async Task<(bool status, string message)> onUpdateProduct(ProductDto productDto)
        {
            
            var res = await productServices.UpdateAsync(productDto);

            if (res == null)
            {
                return (false, "something went wrong");
            }
            return (true, "Product updated successfully");
        }

        public async Task<(bool status, string message)> CreateProduct(ProductDto dto)
        {
            try
            {
                await productServices.AddAsync(dto);
                return (true, "Product created successfully");
            }
            catch (Exception ex)
            {
                return (false, $"${ex.Message}");
            }
        }

        public async Task<List<ProductDto>> GetProducts()
        {
            return await productServices.GetAllAsync();
        }

        public async Task<bool> UpdateProductAsync(List<ProductDto> productDtos)
        {
            return await productServices.UpdateRangeAsync(productDtos);
        }


    }
}
